using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnitTestExample.Controllers;

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
            TestCase("abcdefg", false),
            TestCase("ABCDEFG", false),
            TestCase("Abcdefg1", true)
        ]
        public void TestValidationPassword(string password, bool expectedResult)
        {
            var accountController = new AccountController();

            var actualResult = accountController.ValidateEmail(password);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
