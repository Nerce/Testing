Feature: Feature
	Login to the system

@mytag
Scenario: Login to the system
	When I press Sign In Button
	And I enter email
	And I enter password
	And I press Submit button
	And I see user profile
	And I press Log Out button
	Then I don't see user profile