using System;
using System.Data;
using ContactsDataAccessLayer;
using PeopleDataAccessLayer;


namespace ContactsBusinessLayer
{
    public class clsCountry
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string NationalNo { set; get; }

        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public string ImagePath { set; get; }

        public int CountryID { set; get; }
        public string CountryName { set; get; }


        public clsCountry()

        {
            this.ID = -1;
            this.CountryName = "";

            Mode = enMode.AddNew;

        }

        private clsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        

            Mode = enMode.Update;

        }





        public static clsCountry Find(int ID)
        {

            string CountryName = "";



            int CountryID = -1;

            if (clsCountryData.GetCountryInfoByID(CountryName, ref ID))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }

        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.ID = PeopleDataAccess.AddNewPerosn(
     this.FirstName,
     this.SecondName,
     this.ThirdName,
     this.LastName,
     this.NationalNo,
     this.Email,
     this.Phone,
     this.Address,
     this.DateOfBirth,
     this.CountryID,
     this.ImagePath
 );
            return (this.ID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return PeopleDataAccess.UpdatePerson(
      this.ID,
      this.FirstName,
      this.SecondName,
      this.ThirdName,
      this.LastName,
      this.NationalNo,
      this.Email,
      this.Phone,
      this.Address,
      this.DateOfBirth,
      this.CountryID,
      this.ImagePath
  );

        }

        //public static clsCountry Find(string CountryName)
        //{

        //    int ID = -1;
        //    string Code = "";
        //    string PhoneCode = "";


        //    if (clsCountryData.GetCountryInfoByName(CountryName, ref ID, ref Code, ref PhoneCode))

        //        return new clsCountry(ID, CountryName, Code, PhoneCode);
        //    else
        //        return null;

        //}


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();

        }

        public static bool DeleteCountry(int ID)
        {
            return clsCountryData.DeleteCountry(ID);
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryData.IsCountryExist(ID);
        }

        public static bool isCountryExist(string CountryName)
        {
            return clsCountryData.IsCountryExist(CountryName);
        }



    }
}
