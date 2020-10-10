using AutomationFramework.Base;
using AutomationFramework.PageObjects;
using TechTalk.SpecFlow;

namespace MySwoleMate_Specs.Steps
{
    [Binding]
    public class TraineeSteps : BaseStep
    {
        private readonly ParallelConfig _parallelConfig;

        public TraineeSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
