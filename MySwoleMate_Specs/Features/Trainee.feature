Feature: Trainee
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Browser_Chrome
@TestingTag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen


@Browser_Chrome
@TestingTag
Scenario: Add three numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen