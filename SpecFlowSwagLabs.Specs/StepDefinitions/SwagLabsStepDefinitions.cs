using SpecFlowSwagLabs.Specs.Drivers;
using SpecFlowSwagLabs.Specs.PageObjects;

namespace SpecFlowSwagLabs.Specs.StepDefinitions
{
    [Binding]
    public sealed class SwagLabsStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public SwagLabsStepDefinitions(BrowserDriver driver)
        {
            _loginPage = new LoginPage(driver.Current);
        }

        [Given("the user navigates to login page")]
        public void GivenTheUserNavigatesToLoginPage()
        {
            _loginPage.NavigateToSwagLabs();
        }

        [Given("enters username (.*)")]
        public void GivenTheUsernameIs(string username)
        {
            _loginPage.EnterUsername(username);
        }

        [Given("enters password (.*)")]
        public void GivenThePasswordIs(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When("the login button is clicked")]
        public void WhenTheLoginButtonIsClicked()
        {
            _loginPage.ClickLogin();
        }

        [Then("the user should be redirected to (.*)")]
        public void ThenTheUserShouldBeRedirectedTo(string url)
        {
            _loginPage.GetCurrentUrl(url).Should().Be(url);
        }
    }
}