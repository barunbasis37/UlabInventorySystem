using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULABInventory.Model;
using ULABInventory.ViewModels;

namespace ULABInventory.Service
{
    public class SchoolService
    {
        //Create a Db object
        InventoryDbContext dbContext = new InventoryDbContext();
        public List<SchoolVM> GetList()
        {
            //db.school data
            //Pulls all data into Ram
            var list = dbContext.School.OrderBy(x => x.PriorityLevel).ToList();
            //Convert This data into View data
            var schoolViewModel = new List<SchoolVM>();
            foreach (School school in list)
            {
                SchoolVM aSchoolVm = new SchoolVM(school);
                schoolViewModel.Add(aSchoolVm);
            }
            return schoolViewModel;

        }

        public SchoolVM Details(string id)
        {
            School aSchool=dbContext.School.Find(id);
            return new SchoolVM(aSchool);

        }

        public bool Save(School school)
        {
            string schoolIdMax = dbContext.School.Max(scId => scId.SchoolId);
            string schoolIdNo;
            if (schoolIdMax == null)
            {
                schoolIdNo = String.Format("SCH-01");
            }
            else
            {
                schoolIdNo = String.Format("SCH-" + "{0:D2}", Convert.ToInt32(schoolIdMax.Substring(4)) + 1);
            }
            school.SchoolId = schoolIdNo;


            School add=dbContext.School.Add(school);
            dbContext.SaveChanges();
            return true;
        }

        public bool Update(School school)
        {
            dbContext.Entry(school).State=EntityState.Modified;
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(School school)
        {
            School dbSchool=dbContext.School.FirstOrDefault(sId => sId.QueryId == school.QueryId);
            //School of Business
            dbContext.School.Remove(dbSchool);
            dbContext.SaveChanges();
            return true;
        }

        public School GetDbObject(Guid? id)
        {
            School school=dbContext.School.FirstOrDefault(sId=>sId.QueryId==id);
            return school;
        }
    }
}
