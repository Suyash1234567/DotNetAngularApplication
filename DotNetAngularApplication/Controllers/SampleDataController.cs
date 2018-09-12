using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetAngularApplication.Models;
using DotNetAngularApplication.Data;

namespace DotNetAngularApplication.Controllers
{


    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        List<TransactionViewModel> transactionData = TransactionData.GetTransaction();
        List<StudentViewModel> studentData = StudentData.GetStudent();

        [HttpGet("[action]")]
        public List<StudentJoinedData> GetStudent() 
        {

        //[HttpGet("[action]")]
            List<StudentJoinedData> studentJointList = (from stdntData in studentData
                                                        join stdntTrans in transactionData
                                                        on stdntData.StudentId equals stdntTrans.StudentId
                                                        select new StudentJoinedData
                                                        {
                                                            StudentId = stdntData.StudentId,
                                                            StudentName = stdntData.StudentName,
                                                            StudentClass = stdntData.StudentClass,
                                                            StudentAge = stdntData.StudentAge,
                                                            StudentFees = stdntTrans.StudentFees,
                                                            Date = stdntTrans.Date
                                                        }
                                                    ).ToList();    //to convert the selected data into list
            //JointViewList recieveViewData = new JointViewList();
            //recieveViewData.StudentAllRecords = studentJointList;
            return studentJointList;
            //var model = StudentData.GetStudent();
            //return View(model);
        }

        [HttpGet("[action]")]
        public List<StudentViewModel> SearchByName(string student)
        //[HttpPost("[action]")]
        //public List<StudentViewModel> SearchByName(Student student)
        {
            if (student != null)
            {
                var model = StudentData.GetStudentByName(student);
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }


        //public List<StudentJoinedData> Search(SearchFilter searchFilter)
        //{

        //    if (searchFilter.searchBy == "StudentName")
        //    {
        //        if (!string.IsNullOrWhiteSpace(searchFilter.text))
        //        {
        //            var model = StudentData.GetStudentByName(searchFilter.text);

        //            List<StudentViewModel> myModel = null;
        //            if (searchFilter.sortBy != null)
        //            {
        //                myModel = sortMe(searchFilter.sortBy, model);
        //            }
        //            else
        //            {
        //                myModel = model;
        //            }
        //            if (myModel != null)
        //            {
        //                List<StudentJoinedData> myModel1 = getFilteredRange(myModel, searchFilter.minRange, searchFilter.maxRange);
        //                //return PartialView("_StudentDetails", myModel1);
        //return myModel1

        //            }
        //        }
        //        else
        //        {
        //            List<StudentJoinedData> myModel1 = getFilteredRange(studentData, searchFilter.minRange, searchFilter.maxRange);
        //            return PartialView("_StudentDetails", myModel1);
        //return myModel1
        //        }


        //    }
        //    else if (searchFilter.searchBy == "StudentID")
        //    {
        //        if (!string.IsNullOrWhiteSpace(searchFilter.text))
        //        {
        //            var model = StudentData.GetStudentById(Convert.ToInt32(searchFilter.text));

        //            List<StudentViewModel> myModel = null;
        //            if (searchFilter.sortBy != null)
        //            {
        //                myModel = sortMe(searchFilter.sortBy, model);
        //            }
        //            else
        //            {
        //                myModel = model;
        //            }
        //            if (myModel != null)
        //            {
        //                List<StudentJoinedData> myModel1 = getFilteredRange(myModel, searchFilter.minRange, searchFilter.maxRange);
        //                return PartialView("_StudentDetails", myModel1);
        //            }
        //        }
        //        else
        //        {
        //            List<StudentJoinedData> myModel1 = getFilteredRange(studentData, searchFilter.minRange, searchFilter.maxRange);
        //            return PartialView("_StudentDetails", myModel1);
        //        }
        //    }
        //    else if (searchFilter.searchBy == "StudentAge")
        //    {
        //        if (!string.IsNullOrWhiteSpace(searchFilter.text))
        //        {
        //            var model = StudentData.GetStudentByAge(Convert.ToInt32(searchFilter.text));
        //            List<StudentViewModel> myModel = null;
        //            if (searchFilter.sortBy != null)
        //            {
        //                myModel = sortMe(searchFilter.sortBy, model);
        //            }
        //            else
        //            {
        //                myModel = model;
        //            }
        //            if (myModel != null)
        //            {
        //                List<StudentJoinedData> myModel1 = getFilteredRange(myModel, searchFilter.minRange, searchFilter.maxRange);
        //                return PartialView("_StudentDetails", myModel1);
        //            }
        //        }
        //        else
        //        {
        //            List<StudentJoinedData> myModel1 = getFilteredRange(studentData, searchFilter.minRange, searchFilter.maxRange);
        //            return PartialView("_StudentDetails", myModel1);
        //        }
        //    }
        //    else if (searchFilter.searchBy == "StudentClass")
        //    {
        //        if (!string.IsNullOrWhiteSpace(searchFilter.text))
        //        {
        //            var model = StudentData.GetStudentByClass(Convert.ToInt32(searchFilter.text));
        //            List<StudentViewModel> myModel = null;
        //            if (searchFilter.sortBy != null)
        //            {
        //                myModel = sortMe(searchFilter.sortBy, model);
        //            }
        //            else
        //            {
        //                myModel = model;
        //            }
        //            if (myModel != null)
        //            {
        //                List<StudentJoinedData> myModel1 = getFilteredRange(myModel, searchFilter.minRange, searchFilter.maxRange);
        //                return PartialView("_StudentDetails", myModel1);
        //            }
        //        }
        //        else
        //        {
        //            List<StudentJoinedData> myModel1 = getFilteredRange(studentData, searchFilter.minRange, searchFilter.maxRange);
        //            return PartialView("_StudentDetails", myModel1);
        //        }
        //    }
        //    else
        //    {
        //        List<StudentJoinedData> myModel1 = getFilteredRange(studentData, searchFilter.minRange, searchFilter.maxRange);
        //        return PartialView("_StudentDetails", myModel1);
        //    }


        //    return null;
        //}

        //public List<StudentViewModel> sortMe(string sortyBy, List<StudentViewModel> studentData)
        //{
        //    if (sortyBy == "StudentID")
        //    {
        //        return studentData.OrderBy(x => x.StudentId).ToList(); // for order by ascending
        //        //return studentData.OrderByDescending(x => x.StudentId).ToList(); // For order by descending
        //    }
        //    else if (sortyBy == "StudentName")
        //    {
        //        return studentData.OrderBy(x => x.StudentName).ToList();
        //    }
        //    else if (sortyBy == "StudentClass")
        //    {
        //        return studentData.OrderBy(x => x.StudentClass).ToList();
        //    }
        //    else if (sortyBy == "StudentAge")
        //    {
        //        return studentData.OrderBy(x => x.StudentAge).ToList();
        //    }
        //    return null;
        //}




        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //public List<StudentJoinedData> getFilteredRange(List<StudentViewModel> model, double minRange, double maxRange)
        //{
        //    List<StudentJoinedData> studentJointList1 = (from stdntData in model
        //                                                 join stdntTrans in transactionData
        //                                                on stdntData.StudentId equals stdntTrans.StudentId
        //                                                 select new StudentJoinedData
        //                                                 {
        //                                                     StudentId = stdntData.StudentId,
        //                                                     StudentName = stdntData.StudentName,
        //                                                     StudentClass = stdntData.StudentClass,
        //                                                     StudentAge = stdntData.StudentAge,
        //                                                     StudentFees = stdntTrans.StudentFees,
        //                                                     Date = stdntTrans.Date
        //                                                 }
        //                                             ).ToList();

        //    List<StudentJoinedData> studentJointEAddList = new List<StudentJoinedData>();

        //    if (minRange > 0 && maxRange > 0)
        //    {
        //        foreach (var item in studentJointList1)
        //        {
        //            if (item.StudentFees >= minRange && item.StudentFees <= maxRange)
        //            {
        //                studentJointEAddList.Add(item);
        //                //return studentJointList1;
        //            }
        //        }
        //        return studentJointEAddList;
        //    }

        //    return studentJointList1;


        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}










































        //private static string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //[HttpGet("[action]")]
        //public IEnumerable<WeatherForecast> WeatherForecasts()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}

        //public class WeatherForecast
        //{
        //    public string DateFormatted { get; set; }
        //    public int TemperatureC { get; set; }
        //    public string Summary { get; set; }

        //    public int TemperatureF
        //    {
        //        get
        //        {
        //            return 32 + (int)(TemperatureC / 0.5556);
        //        }
        //    }
        //}
    }
}
