using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Infrastructure.Mappers;
using System.Web.Mvc;
using BLL.Interfaces;
using MVC.Models.Shared;
using MVC.Models.Client;
using MVC.Models.Pagging;
using MVC.CustomProviders;
using System.Web.Security;
using MVC.Helpers;

namespace MVC.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ITestService testService;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
        private readonly ICategoryService categoryService;
        private readonly IClientService clientService;
        private readonly IPassedTestService passedTestService;
        private int pageSize = 6;
        private static bool isStatisticFlag = false;
        private string dateTimeKey = "DateTimeKey";
        private string passingTestKey = "PassingTestKey";

        public ClientController(ITestService testService, IQuestionService questionService, IAnswerService answerService, 
            ICategoryService categoryService, IClientService clientService, IPassedTestService passedTestService)
        {
            this.testService = testService;
            this.questionService = questionService;
            this.answerService = answerService;
            this.categoryService = categoryService;
            this.clientService = clientService;
            this.passedTestService = passedTestService;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            var tests = testService.GetAllTestEntities().Select(test => test.ToMvcTest());

            if (tests == null) return HttpNotFound();

            tests = tests.OrderByDescending(test => test.DateOfCreation).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = pageNumber, PageSize = pageSize, TotalItems = tests.Count()
                },
                PageContent = tests.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            };
            isStatisticFlag = false;

            return View(page);
        }

        [HttpGet]
        public ActionResult ViewStatistic(int pageNumber = 1)
        {
            var client = clientService.GetClientByEmail(User.Identity.Name).ToMvcRegisterClient();
            var passedTests = passedTestService.GetPassedTestsByClientId(client.Id)
                .Select(passedTest => passedTest.ToMvcPassedTest()).ToList();

            if (passedTests == null) return HttpNotFound();

            foreach (var passedTest in passedTests)
            {
                passedTest.TestName = testService.GetTestEntity(passedTest.TestId).TestName;
                passedTest.CountOfQuestions = questionService.GetQuestionEntitiesByTestId(passedTest.TestId).Count();
            }
            passedTests = passedTests.OrderByDescending(test => test.DateOfPass).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = passedTests.Count()
                },
                PassedTests = passedTests.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList()
            };

            isStatisticFlag = true;
            return View(page);
        }

        #region Search_By_Category_Or_Token

        [HttpGet]
        public ActionResult ViewCategory(int categoryId = 0)
        {
            string actionName = (isStatisticFlag) ? "ViewStatisticTestsOfCategory" : "ViewTestsOfCategory";

            return RedirectToAction(actionName, new { categoryId = categoryId } );
        }

        [HttpGet]
        public ActionResult ViewTestsOfCategory(int categoryId = 0)
        {
            var tests = testService.GetTestsByCategoryId(categoryId).Select(test => test.ToMvcTest());

            if (tests == null) return HttpNotFound();

            tests = tests.OrderByDescending(test => test.DateOfCreation).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = 1,
                    PageSize = pageSize,
                    TotalItems = tests.Count()
                }
            };
            
            page.PageContent = tests.Take(pageSize).ToList();
            return View("Index", page);
        }

        [HttpGet]
        public ActionResult ViewStatisticTestsOfCategory(int categoryId = 0)
        {
            int clientId = clientService.GetClientByEmail(User.Identity.Name).Id;
            var passedTests = passedTestService.GetPassedTestByCategoryAndClientId(categoryId, clientId)
                .Select(passedTest => passedTest.ToMvcPassedTest()).ToList();

            if (passedTests == null) return HttpNotFound();

            foreach (var passedTest in passedTests)
            {
                passedTest.TestName = testService.GetTestEntity(passedTest.TestId).TestName;
                passedTest.CountOfQuestions = questionService.GetQuestionEntitiesByTestId(passedTest.TestId).Count();
            }
            passedTests = passedTests.OrderByDescending(test => test.DateOfPass).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = 1,
                    PageSize = pageSize,
                    TotalItems = passedTests.Count()
                }
            };
            
            page.PassedTests = passedTests.Take(pageSize).ToList();
            return View("ViewStatistic", page);
        }

        [HttpPost]
        public ActionResult SearchByName(PageViewModel page)
        {
            string actionName = (isStatisticFlag) ? "SearchStatisticByTestName" : "SearchByTestName";

            return RedirectToAction(actionName, new { token = page.SearchingToken });
        }

        [HttpGet]
        public ActionResult SearchByTestName(string token)
        {
            var tests = testService.GetTestsBySearchingToken(token).Select(test => test.ToMvcTest()).ToList();

            if (tests == null) return HttpNotFound();

            tests = tests.OrderByDescending(test => test.DateOfCreation).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = 1,
                    PageSize = pageSize,
                    TotalItems = tests.Count
                }
            };

            page.PageContent = tests.Take(pageSize).ToList();
            return View("Index", page);
        }

        [HttpGet]
        public ActionResult SearchStatisticByTestName(string token)
        {
            int clientId = clientService.GetClientByEmail(User.Identity.Name).Id;
            var passedTests = passedTestService.GetPassedTestBySearchingToken(token, clientId)
                .Select(passedTest => passedTest.ToMvcPassedTest()).ToList();

            if (passedTests == null) return HttpNotFound();

            foreach (var passedTest in passedTests)
            {
                passedTest.TestName = testService.GetTestEntity(passedTest.TestId).TestName;
                passedTest.CountOfQuestions = questionService.GetQuestionEntitiesByTestId(passedTest.TestId).Count();
            }
            passedTests = passedTests.OrderByDescending(test => test.DateOfPass).ToList();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = 1,
                    PageSize = pageSize,
                    TotalItems = passedTests.Count()
                }
            };

            page.PassedTests = passedTests.Take(pageSize).ToList();
            return View("ViewStatistic", page);
        }

        #endregion

        //[HttpGet]
        public ActionResult GetCategories()
        {
            var allCategories = categoryService.GetAllCategoryEntities().Select(category => category.ToMvcCategory()).ToList();

            if (isStatisticFlag)
            {
                int clientId = clientService.GetClientByEmail(User.Identity.Name).Id;

                foreach (var category in allCategories)
                {
                    category.TestsCount = passedTestService.GetPassedTestByCategoryAndClientId(category.Id, clientId).Count();
                }
            }
            else
            {
                foreach (var category in allCategories)
                {
                    category.TestsCount = testService.GetTestsByCategoryId(category.Id).Count();
                }
            }

            return PartialView("_Categories", allCategories);
        }

        [HttpGet]
        public ActionResult ChooseTestMode(int testId)
        {
            TestViewModel test = testService.GetTestEntity(testId).ToMvcTest();
            return View(test);
        }

        [HttpGet]
        public ActionResult PassUsual(int id)
        {
            return RedirectToAction("PassTest", new { testId = id });
        }

        [HttpGet]
        public ActionResult PassOnTime(int id)
        {
            TempData[dateTimeKey] = DateTime.Now;
            return RedirectToAction("PassTest", new { testId = id });
        }

        [HttpGet]
        public ActionResult PassTest(int testId = 0)
        {
            var questions = questionService.GetQuestionEntitiesByTestId(testId)
                .Select(question => question.ToMvcQuestion()).ToList();
            var passedQuestions = new List<QuestionViewModel>();

            if ((questions != null) && (questions.Count != 0))
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    passedQuestions.Add(new QuestionViewModel
                    {
                        TestId = testId,
                        Id = questions[i].Id,
                        Image = questions[i].Image,
                        QuestionText = questions[i].QuestionText
                    });

                    var answers = answerService.GetAnswersByQuestionId(questions[i].Id)?.ToList();
                    passedQuestions[i].NewAnswers = answers?
                        .Select(answer => new SelectListItem() { Text = answer.Text, Value = answer.Id.ToString() });
                }

                for (int i = 0; i < questions.Count - 1; i++)
                {
                    passedQuestions[i].NextQuestionId = passedQuestions[i + 1].Id;
                }

                for (int i = 1; i < questions.Count; i++)
                {
                    passedQuestions[i].PrevQuestionId = passedQuestions[i - 1].Id;
                }

                TempData[passingTestKey] = passedQuestions;
                return View(new TestViewModel { Id = testId, CurrentQuestion = passedQuestions[0] });
            }

            return View(new TestViewModel { Id = testId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[MultipleButton(Name = "action", Argument = "PassTest")]
        public ActionResult PassTest(TestViewModel test)
        {
            ResultViewModel result = new ResultViewModel();

            if (ModelState.IsValid)
            {
                DateTime? timeOfStart = null, timeOfFinish = null;
                timeOfFinish = DateTime.Now;

                var passedQuestions = (List<QuestionViewModel>)TempData[passingTestKey];
                var realQuestions = questionService.GetQuestionEntitiesByTestId(test.Id);
                var testEntity = testService.GetTestEntity(test.Id).ToMvcTest();
                var clientId = clientService.GetClientByEmail(User.Identity.Name).Id;
                int i = 0;

                foreach(var question in realQuestions)
                {
                    if (question.RightAnswer == answerService.GetAnswerEntity(passedQuestions[i].AnswerId).ToMvcAnswer().Text)
                    {
                        result.CountOfRightAnswers++;
                    }
                    else
                    {
                        result.WrongResults.Add(i + 1);
                    }
                    i++;
                }

                var existedPassedTest = passedTestService.GetPassedTestsByTestId(test.Id)
                    .Where(passTest => passTest.ClientId == clientId).ToList();

                var passedTest = new PassedTestViewModel
                {
                    TestName = testEntity.TestName,
                    TestId = testEntity.Id,
                    ClientId = clientId,
                    CountOfRightResults = result.CountOfRightAnswers
                };

                passedTest.DateOfPass = timeOfFinish;

                if ((timeOfStart = (DateTime?)TempData[dateTimeKey]) != null)
                {
                    passedTest.TimeToPass = TimeSpan.Parse(string.Format("{0:hh\\:mm\\:ss}", (TimeSpan)(timeOfFinish - timeOfStart)));
                    result.TimeToPass = passedTest.TimeToPass;
                }

                if (existedPassedTest.Count == 0)
                {
                    passedTestService.CreatePassedTestEntity(passedTest.ToBllPassedTest());
                }
                else
                {
                    var passedTestsByTest = passedTestService.GetPassedTestsByTestId(testEntity.Id);
                    var passedTestsByClient = passedTestService.GetPassedTestsByClientId(clientId);
                    foreach(var ptt in passedTestsByTest)
                    {
                        foreach(var ptc in passedTestsByClient)
                        {
                            if (ptc.TestId == ptt.TestId)
                            {
                                passedTest.Id = ptc.Id;
                            }
                        }
                    }
                    passedTestService.UpdatePassedTestEntity(passedTest.ToBllPassedTest());
                }
            }

            return View("Result", result);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "GetPrevQuestion")]
        public ActionResult GetPrevQuestion(QuestionViewModel questionModel)
        {
            var passedQuestions = (List<QuestionViewModel>)TempData[passingTestKey];

            if (ModelState.IsValid)
            {
                int currentQuestionPossition = 0;

                for (int i = 0; i < passedQuestions.Count; i++)
                {
                    if (passedQuestions[i].Id == questionModel.Id)
                    {
                        passedQuestions[i].AnswerId = questionModel.AnswerId;
                        currentQuestionPossition = i;
                        break;
                    }
                }

                TempData[passingTestKey] = passedQuestions;

                var test = new TestViewModel
                {
                    CurrentQuestion = passedQuestions[currentQuestionPossition - 1],
                    Id = questionModel.TestId,
                    CategoryId = testService.GetTestEntity(questionModel.TestId).CategoryId
                };

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ViewQuestion", test.CurrentQuestion);
                }

                return View("PassTest", test);
            }
            
            return View("PassTest", questionModel);
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "GetNextQuestion")]
        public ActionResult GetNextQuestion(QuestionViewModel questionModel)
        {
            var passedQuestions = (List<QuestionViewModel>)TempData[passingTestKey];

            if (ModelState.IsValid)
            {
                int currentPossition = 0;
                var questions = questionService.GetQuestionEntitiesByTestId(questionModel.TestId)
                    .Select(question => question.ToMvcQuestion()).ToList();

                for (int i = 0; i < passedQuestions.Count; i++)
                {
                    if (passedQuestions[i].Id == questionModel.Id)
                    {
                        passedQuestions[i].AnswerId = questionModel.AnswerId;
                        currentPossition = i;
                        break;
                    }
                }
                TempData[passingTestKey] = passedQuestions;
                var nextModel = (questionModel.NextQuestionId != 0) 
                    ? passedQuestions[currentPossition + 1] : new QuestionViewModel { Id = 0 };

                var test = new TestViewModel
                {
                    CurrentQuestion = nextModel,
                    Id = questionModel.TestId,
                    CategoryId = testService.GetTestEntity(questionModel.TestId).CategoryId
                };

                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ViewQuestion", test.CurrentQuestion);
                }

                return View("PassTest", test);
            }

            return View("PassTest", questionModel);
        }
        
        [HttpGet]
        public ActionResult UpdateClientProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateClientProfile(ProfileViewModel profile)
        {   
            foreach(var user in clientService.GetAllClientEntities())
            {
                if ((user.Email == profile.Email) && (profile.Email != User.Identity.Name))
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }

            if (ModelState.IsValid)
            {
                profile.ClientId = clientService.GetClientByEmail(User.Identity.Name).Id;

                ((ClientMembershipProvider)Membership.Provider).UpdateClient(profile);

                if (profile.Email != null)
                {
                    FormsAuthentication.SetAuthCookie(profile.Email, false);
                }

                return RedirectToAction("Index", "Client");
                
            }

            return View(profile);
        }

        [HttpGet]
        public ActionResult About()
        {
            var registerModel = clientService.GetClientByEmail(User.Identity.Name).ToMvcRegisterClient();
            var profile = new ProfileViewModel
            {
                Name = registerModel.Name,
                Surname = registerModel.Surname,
                Patronymic = registerModel.Patronymic,
                Age = registerModel.Age
            };

            return View(profile);
        }

        [HttpGet]
        public ActionResult ChooseBack()
        {
            if (isStatisticFlag)
            {
                return RedirectToAction("ViewStatistic");
            }

            return RedirectToAction("Index");
        }
    }
}