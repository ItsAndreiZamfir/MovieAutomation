Feature: Movies

Tests for the movie db webapp (navigation on movies page and filters)

@navigation @movies
Scenario: Navigation to movies page
	Given I navigate to the movies page
	Then I should be navigated to the "movie" page

@filter @movies
Scenario: Filter movies by release date ascending
	Given I navigate to the movies page
	When I filter movies by "Release Date Ascending"
	* I press search button
	Then the movies should be sorted by release date ascending

@filter @movies
Scenario: Filter movies by gendres
	Given I navigate to the movies page
	When I save the initial list of movies
	* I select genres filters: "Action,Fantasy"
	* I press search button
	Then the movies list should be different from the initial list of movies

@filter @movies
Scenario: Filter movies by release dates
#Note: This test will fail because the filter by release from and release to is not working properly on the web app
	Given I navigate to the movies page
	When I save the initial list of movies
	And I select release dates from "1990" to "2005"
	* I press search button
	Then the movies list should contains only movies released between 1990 and 2005