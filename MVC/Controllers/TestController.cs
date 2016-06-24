using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models.Shared;
using MVC.Models.Admin;
using MVC.Infrastructure.Mappers;
using BLL.Interfaces;
using BLL.Entities;
using MVC.Models.Pagging;
using System.IO;

namespace MVC.Controllers
{
    [Authorize (Roles = "Admin")]
    public class TestController : Controller
    {
        private readonly ITestService service;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
        private readonly ICategoryService categoryService;
        private readonly string addQuestionKey = "AddQuestionKey";
        private readonly int pageSize = 6;

        public TestController(ITestService service, IQuestionService questionService,
            IAnswerService answerService, ICategoryService categoryService)
        {
            this.service = service;
            this.questionService = questionService;
            this.answerService = answerService;
            this.categoryService = categoryService;
        }

        // GET: Admin
        public ActionResult Index(int pageNumber = 1)
        {
            var tests = service.GetAllTestEntities().Select(test => test.ToMvcTest());
            tests = tests.OrderByDescending(test => test.DateOfCreation).ToList();

            if (tests == null) return HttpNotFound();

            var page = new PageViewModel
            {
                PageInfo = new PageInfoModel
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = tests.Count()
                },
                PageContent = tests.Skip((pageNumber - 1) * pageSize).Take(pageSize)
            };

            return View(page);
        }

        #region Test
         
        [HttpGet]
        public ActionResult Create()
        {
            TestViewModel test = new TestViewModel();

            test.Categories = categoryService.GetAllCategoryEntities()
                ?.Select(category => new SelectListItem() { Text = category.CategoryName, Value = category.Id.ToString() });

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestViewModel testViewModel)
        {
            if (service.IsTestWithNameExist(testViewModel.TestName))
            {
                ModelState.AddModelError("", "Test with same name is exist.");
            }

            testViewModel.Categories = categoryService.GetAllCategoryEntities()
                ?.Select(category => new SelectListItem() { Text = category.CategoryName, Value = category.Id.ToString() });

            if (ModelState.IsValid)
            {
                testViewModel.DateOfCreation = DateTime.Now;
                service.CreateTest(testViewModel.ToBllTest());

                foreach(var test in service.GetTestsByName(testViewModel.TestName))
                {
                    testViewModel = test.ToMvcTest();
                }

                AddQuestionViewModel addQuestion = new AddQuestionViewModel { TestId = testViewModel.Id };
                TempData[addQuestionKey] = addQuestion;

                return View("AddQuestions", addQuestion);
            }
            
            return View(testViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            TestViewModel test = service.GetTestEntity(id).ToMvcTest();

            if (test == null) return HttpNotFound();

            test.Categories = categoryService.GetAllCategoryEntities()?
                .Select(category => new SelectListItem() { Text = category.CategoryName, Value = category.Id.ToString() });

            test.Questions = questionService.GetQuestionEntitiesByTestId(id)
                             .Select(question => question.ToMvcQuestion()).ToList();

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestViewModel testViewModel)
        {
            string oldName = service.GetTestEntity(testViewModel.Id).TestName;

            testViewModel.Categories = categoryService.GetAllCategoryEntities()?
                .Select(category => new SelectListItem() { Text = category.CategoryName, Value = category.Id.ToString() });

            if (service.IsTestWithNameExist(testViewModel.TestName) && (oldName != testViewModel.TestName))
            {
                ModelState.AddModelError("", "Test with same name is exist.");
            }

            if (ModelState.IsValid)
            {
                service.UpdateTest(testViewModel.ToBllTest());

                foreach (var test in service.GetTestsByName(testViewModel.TestName))
                {
                    testViewModel = test.ToMvcTest();
                }

                AddQuestionViewModel addQuestion = new AddQuestionViewModel { TestId = testViewModel.Id };

                if (testViewModel.Questions != null)
                {
                    addQuestion.AddedQuestions = testViewModel.Questions?
                        .Select(question => new AddedQuestionRow { Text = question.QuestionText, Image = question.Image }).ToList();
                }

                TempData[addQuestionKey] = addQuestion;

                return View("AddQuestions", addQuestion);
            }

            testViewModel.Questions = questionService.GetQuestionEntitiesByTestId(testViewModel.Id)
                .Select(question => question.ToMvcQuestion()).ToList();

            return View(testViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            TestViewModel test = service.GetTestEntity(id)?.ToMvcTest();

            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TestViewModel testViewModel)
        {
            service.DeleteTest(testViewModel.ToBllTest());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SearchByTestName(PageViewModel pageModel)
        {
            var tests = service.GetTestsBySearchingToken(pageModel.SearchingToken).Select(test => test.ToMvcTest()).ToList();

            if (tests == null) return HttpNotFound();

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
        public ActionResult ViewCategory(int categoryId = 0)
        {
            var tests = service.GetTestsByCategoryId(categoryId).Select(test => test.ToMvcTest()).ToList();

            if (tests == null) return HttpNotFound();

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

        //[HttpGet]
        public ActionResult GetCategories()
        {
            var allCategories = categoryService.GetAllCategoryEntities().Select(category => category.ToMvcCategory()).ToList();

            foreach (var category in allCategories)
            {
                category.TestsCount = service.GetTestsByCategoryId(category.Id).Count();
            }

            return PartialView("_Categories", allCategories);
        }

        #endregion

        #region Question

        [HttpGet]
        public ActionResult CreateQuestion(AddQuestionViewModel addQuestion)
        {
            QuestionViewModel question = new QuestionViewModel() { TestId = addQuestion.TestId };
            return View("CreateQuestion", question);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateQuestion(QuestionViewModel question = null, HttpPostedFileBase uploadImage = null)
        {
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if (question.Answers[i] == "")
                {
                    ModelState.AddModelError("", "Some fields didn't set.");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        question.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                }

                question.Id = questionService.CreateQuestion(question.ToBllQuestion());
                int i = 0;

                foreach(var answer in question.Answers)
                {
                    i++;
                    answerService.CreateAnswer(new AnswerEntity { QuestionId = question.Id, Text = answer, Number = i });
                }

                AddQuestionViewModel addQuestion = (AddQuestionViewModel)TempData[addQuestionKey];
                var questionRow = new AddedQuestionRow { Text = question.QuestionText, Image = question.Image };
                addQuestion.AddedQuestions.Add(questionRow);
                TempData[addQuestionKey] = addQuestion;

                return View("AddQuestions", addQuestion);
            }

            return View(question);
        }

        [HttpGet]
        public ActionResult EditQuestion(int id = 0)
        {   
            QuestionViewModel questionViewModel = questionService.GetQuestionEntity(id)?.ToMvcQuestion();

            if (questionViewModel == null)
            {
                return HttpNotFound();
            }

            questionViewModel.Answers = answerService.GetAnswersByQuestionId(id).Select(answer => answer.Text).ToList();

            return View(questionViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditQuestion(QuestionViewModel question, HttpPostedFileBase uploadImage = null)
        {
            for (int i = 0; i < question.Answers.Count; i++)
            {
                if ((question.Answers[i] == null) && (question.Answers[i] == ""))
                {
                    ModelState.AddModelError("", "Some fields didn't set.");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        question.Image = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                }

                questionService.UpdateQuestion(question.ToBllQuestion());
                question.TestId = questionService.GetQuestionEntity(question.Id).TestId;
                var answers = answerService.GetAnswersByQuestionId(question.Id).ToList();

                for (int i = 0; i < question.Answers.Count; i++)
                {
                    answers[i].Text = question.Answers[i];
                    answers[i].Number = i;
                    answerService.UpdateAnswer(answers[i]);
                }

                return RedirectToAction("Edit", new { id = question.TestId });
            }

            return View(question);
        }

        //GET-запрос к методу Delete несет потенциальную уязвимость!
        [HttpGet]
        public ActionResult DeleteQuestion(int id = 0)
        {
            QuestionViewModel questionViewModel = questionService.GetQuestionEntity(id)?.ToMvcQuestion();

            if (questionViewModel == null)
            {
                return HttpNotFound();
            }

            return View(questionViewModel);
        }

        [HttpPost, ActionName("DeleteQuestion")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedQuestion(QuestionViewModel question)
        {
            questionService.DeleteQuestion(question.ToBllQuestion());
            return RedirectToAction("Index");
        }
        #endregion
    }
}