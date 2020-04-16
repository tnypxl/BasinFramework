Feature: Search

A short summary of the feature

Scenario: Searching for cats returns relevant results
	Given I am on the home page
	And I want to know the definition of the word "cat"
	When I perform a search
	Then I should see the word "cat" defined as
	"""
A small domesticated carnivorous mammal (Felis catus), kept as a pet and as catcher of vermin, and existing in a variety of breeds.
	"""
	
