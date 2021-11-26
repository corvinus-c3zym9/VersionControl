using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using UnitTestExample.Controllers;
using System.Activities;

namespace UnitTestExample.Tests
{
    class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false), //amikor valaki véletlenül a jelszót az e-mailhez írta
            TestCase("irf@uni-corvinus", false), //amikor lemarad a domain az e-mail végéről
            TestCase("irf.uni-corvinus.hu", false), //amikor kimarad a @ jel
            TestCase("irf@uni-corvinus.hu", true) //amikor rendben van az e-mail; ez az egy eset, amikor a validálásnak true-t kell visszaadni
        ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            //arrange rész - a tesztelészhez szükséges elemek összegyűjtése és beállítása
                //példányosítom az AccountController osztályt
            var accountController = new AccountController();

            //act rész - a tesztelni kívánt tevékenység végrehajtása
                //meghívom a vezérlő ValidateEmail függvényét a bemenő email paraméterrel és ezt eltárolom egy változóban
                //vagyis létrehozok egy változót és azt egyenlővé teszem az AccountController-ben létreozott validate email függvényével
                //a ValidateEmail-nek 2 paramétere volt - egy string email és egy bool expectedResult
            var actualResult = accountController.ValidateEmail(email);

            //assert rész - egy statikus függvény segítségével - AreEqual - megnézzük, hogy az expectedResult és az actualResult megegyezik e
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedResult, actualResult);

        }

        [
            Test,
            TestCase("abcd1234", false),
            TestCase("ABCD1234", false),
            TestCase("abcdABCD", false),
            TestCase("abcdAB1234", false),
            TestCase("abcdABCD1234", true)
        ]
        public void TestValidationPassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(password);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedResult, actualResult);
        }


        [
            Test,
            TestCase("irf@uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
        ]
        public void TestRegisterHappyPass(string email, string password)
        {
            var accountController = new AccountController();

            var actualResult = accountController.Register(email, password);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(email, actualResult.Email);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(password, actualResult.Password);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }


        [
            Test,
            TestCase("irf@uni-corvinus", "Abcd1234"),
            TestCase("irf.uni-corvinus.hu", "Abcd1234"),
            TestCase("irf@uni-corvinus.hu", "abcd1234"),
            TestCase("irf@uni-corvinus.hu", "ABCD1234"),
            TestCase("irf@uni-corvinus.hu", "abcdABCD"),
            TestCase("irf@uni-corvinus.hu", "Ab1234"),
        ]
        public void TestRegisterValidateException(string email, string password)
        {
            var accountController = new AccountController();

            try
            {
                var actualResult = accountController.Register(email, password);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail();
            }
            catch (Exception ex)
            {

                NUnit.Framework.Assert.IsInstanceOf<ValidationException>(ex);
            }
            
        }
    }
}
