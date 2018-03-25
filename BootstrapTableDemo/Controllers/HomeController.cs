using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BootstrapTableDemo.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace BootstrapTableDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly EditableDemoDBContext _context;

        public HomeController(EditableDemoDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public JsonResult GetInfo(int limit, int offset, string departmentname, string statu)
        {
            //var lstRes = new List<Department>();
            //for (var i = 0; i < 200; i++)
            //{
            //    var oModel = new Department();
            //    oModel.ID = Guid.NewGuid().ToString();
            //    oModel.Name = "销售部" + i;
            //    oModel.Level = i.ToString();
            //    oModel.Desc = "暂无描述信息";
            //    lstRes.Add(oModel);
            //}
            var lstRes = _context.EmployeesList.FromSql("SELECT * FROM EmployeeList").ToList();
            var rows = lstRes.ToList();
            if (!string.IsNullOrEmpty(departmentname))
            {
                rows = rows.Where(e => e.Name.Contains(departmentname)).ToList();
            }
            var total = rows.Count;
            rows = rows.Skip(offset).Take(limit).ToList();

            return Json(new { total, rows });
        }

        [HttpPost]
        public JsonResult Edit(EmployeeList employeeList)
        {

            return Json(new { });
        }

        public JsonResult GetDepartments()
        {
            var lstRes = _context.InfoDepartments.ToList();

            return Json(lstRes);
        }

        public IActionResult TestJqueryCache()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Department
    {
        [JsonProperty("ID")]
        public string ID { set; get; }
        [JsonProperty("Name")]
        public string Name { set; get; }
        [JsonProperty("ParentName")]
        public string ParentName { set; get; }
        [JsonProperty("Level")]
        public string Level { set; get; }
        [JsonProperty("Desc")]
        public string Desc { set; get; }
    }

    public class Part
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
