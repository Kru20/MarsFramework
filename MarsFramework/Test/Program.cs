using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Save()
            {
                SignIn signin = new SignIn();
                ShareSkill skills = new ShareSkill();
                skills.EnterShareSkill();
                             

            }

            [Test]
            public void Edit()
            {
                SignIn sign = new SignIn();
                ManageListings manage = new ManageListings();
                manage.EditSkills();
            }
            [Test]
            public void Cancel()
            {
                SignIn signin = new SignIn();
                ShareSkill skills = new ShareSkill();
                skills.CancelSkill();
            }
            [Test]
            public void View()
            {
                SignIn signin = new SignIn();
                ManageListings manage = new ManageListings();
                manage.Listings();
            }
            [Test]
            public void Delete()
            {
                SignIn signin = new SignIn();
                ManageListings manage = new ManageListings();
                manage.DeleteSkills();
            }
        }
    }
}