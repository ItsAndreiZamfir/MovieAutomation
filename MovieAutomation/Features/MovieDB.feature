Feature: Movies

Tests for the movie db webapp

@testtag
Scenario: Use the navigation menu
	Given I navigate to the movies page
	Then I should be navigated to the "movie" page