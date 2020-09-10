Feature: Parent Locators
	Find MY PARENTS! I'm LOST!

Background:
	Given I am on the home page
	When I navigate to the example named 'Large & Deep DOM'

Scenario: Locates parent of element
	Then I can locate the first parent of element

Scenario: Locates specific parent of element
	Then I can locate parent '1.1' of element '2.1'