using baicuoiky_zanhanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace baicuoiky_zanhanh.Controllers
{
    public class QuanlyNhatreController : Controller
    {
        // GET: QuanlyNhatre
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListLop()
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            List<LOP> dsLop = db.LOPs.ToList();
            return View(dsLop);
        }
        public ActionResult ListTre(int MALOP)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            List<TRE> dsTre = db.TREs
                .Where(x => x.MALOP == MALOP)
                .ToList();
            return View(dsTre);
        }
        public ActionResult ListBaomau(int MALOP)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            List<BAOMAU> dsBaomau = db.BAOMAUs
                .Where(x => x.MALOP == MALOP)
                .ToList();
            return View(dsBaomau);
        }
        public ActionResult DeleteTre(int MATRE)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            TRE tre = db.TREs.FirstOrDefault(x => x.MATRE == MATRE);
            if (tre != null)
            {
                db.TREs.DeleteOnSubmit(tre);
                db.SubmitChanges();
            }
            return RedirectToAction("ListLop");
        }
        public ActionResult EditTre(int MATRE)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            TRE tre = db.TREs.FirstOrDefault(x => x.MATRE == MATRE);

            if (Request.Form.Count == 0)
            {
                return View(tre);
            }
            string TENTRE = Request.Form["TENTRE"];
            string MAtre = Request.Form["MAtre"];
            string NAMSINH = Request.Form["NAMSINH"];
            string MALOP = Request.Form["MALOP"];
            string TENLOP = Request.Form["TENLOP"];
            string PHAI = Request.Form["PHAI"];
            string DCHI = Request.Form["DCHI"];
            tre.TENTRE = TENTRE;
            tre.MATRE = int.Parse(MAtre);
            tre.NAMSINH = int.Parse(NAMSINH);
            tre.MALOP = int.Parse(MALOP);
            tre.TENLOP = TENLOP;
            tre.PHAI = PHAI;
            tre.DCHI = DCHI;
            db.SubmitChanges();
            return RedirectToAction("ListLop");

        }
        public ActionResult CreateTre()
        {
            if (Request.Form.Count > 0)
            {
                string TENTRE = Request.Form["TENTRE"];
                string MAtre = Request.Form["MAtre"];
                string NAMSINH = Request.Form["NAMSINH"];
                string MALOP = Request.Form["MALOP"];
                string TENLOP = Request.Form["TENLOP"];
                string PHAI = Request.Form["PHAI"];
                string DCHI = Request.Form["DCHI"];
                QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
                TRE objtre = new TRE();
                objtre.TENTRE = TENTRE;
                objtre.MATRE = int.Parse(TaoMaKhoa());
                objtre.NAMSINH = int.Parse(NAMSINH);
                objtre.MALOP = int.Parse(MALOP);
                objtre.TENLOP = TENLOP;
                objtre.PHAI = PHAI;
                objtre.DCHI = DCHI;
                db.TREs.InsertOnSubmit(objtre);
                db.SubmitChanges();
                return RedirectToAction("ListLop");
            }
            return View();
        }
        public ActionResult Searchlop(string name)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            List<LOP> dslop = db.LOPs
                .Where(x => x.TENLOP == name)
                .ToList();
            return View("ListLop", dslop);
        }
        public ActionResult DeleteBm(int MABM)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            BAOMAU baomau = db.BAOMAUs.FirstOrDefault(x => x.MABM == MABM);
            if (baomau != null)
            {
                db.BAOMAUs.DeleteOnSubmit(baomau);
                db.SubmitChanges();
            }
            return RedirectToAction("ListLop");
        }
        public ActionResult EditBm(int MABM)
        {
            QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
            BAOMAU bm = db.BAOMAUs.FirstOrDefault(x => x.MABM == MABM);

            if (Request.Form.Count == 0)
            {
                return View(bm);
            }
            string HOTEN = Request.Form["HOTEN"];
            string MAbm = Request.Form["MAbm"];
            string PHAI = Request.Form["PHAI"];
            string LUONG = Request.Form["LUONG"];
            string MALOP = Request.Form["MALOP"];
            string TENLOP = Request.Form["TENLOP"];
            string DIACHI = Request.Form["DIACHI"];
            bm.HOTEN = HOTEN;
            bm.MABM = int.Parse(MAbm);
            bm.PHAI = PHAI;
            bm.LUONG = int.Parse(LUONG);
            bm.TENLOP = TENLOP;
            bm.MALOP = int.Parse(MALOP);
            bm.DIACHI = DIACHI;
            db.SubmitChanges();
            return RedirectToAction("ListLop");

        }
        public ActionResult CreateBm()
        {
            if (Request.Form.Count > 0)
            {
                string HOTEN = Request.Form["HOTEN"];
                string MAbm = Request.Form["MAbm"];
                string PHAI = Request.Form["PHAI"];
                string LUONG = Request.Form["LUONG"];
                string MALOP = Request.Form["MALOP"];
                string TENLOP = Request.Form["TENLOP"];
                string DIACHI = Request.Form["DIACHI"];
                QuanlyNhatreDataContext db = new QuanlyNhatreDataContext();
                BAOMAU objBm = new BAOMAU();
                objBm.HOTEN = HOTEN;
                objBm.MABM = int.Parse(TaoMaKhoa());
                objBm.PHAI = PHAI;
                objBm.LUONG = int.Parse(LUONG);
                objBm.TENLOP = TENLOP;
                objBm.MALOP = int.Parse(MALOP);
                objBm.DIACHI = DIACHI;
                db.BAOMAUs.InsertOnSubmit(objBm);
                db.SubmitChanges();
                return RedirectToAction("ListLop");
            }
            return View();
        }
        private string TaoMaKhoa()
        {
            DateTime now = DateTime.Now;
            string ma = now.ToString("ffffff"); // Lấy 3 chữ số cuối cùng
            return ma;
        }
    }
}