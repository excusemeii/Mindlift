# Mindlift
## Design Document
Authors: Yash Bheke, Abhishek Badola, Kanchan Joshi, Deepika Srivastava, Vaishnovi Palaparthy

## Introduction
In today's fast-paced world, self-help literature provides valuable insights and tools for personal growth. Our Self-Help Books website aims to be a comprehensive platform where users can explore, engage with, and read reviews of self-help books. The website will feature:
- •	A vast selection of self-help books across various categories.
- •	Detailed book information and user reviews to assist in making informed decisions.
- •	Options for purchasing books through a third-party website.
- •	Integrations with YouTube for video content related to self-help topics.
- •	Robust user account management to enhance user experience and personalization.

## Logo
![Mindlift Logo](MINdLIFT (1).png)
The Self-Help Bookstore logo features an open book with a glowing light bulb above it, symbolizing knowledge and inspiration, set against a calming background.

## Data Feeds
- •	OpenLibrary API: [For accessing book data, reviews, and ratings.] (https://openlibrary.org/search.json?q=atomic+habits)
- •	YouTube API: [To pull in relevant video content related to self-help topics and featured authors.](https://www.youtube.com/watch?v=2xzIc-sY-cA&%26api-key%3D76363c9e70bc401bac1e6ad88b13bd1d=AIzaSyAOXJ2dt6Zzc1sRMjG0NeB6lwVDtpcQ-_E)
- •	E-commerce Platform: For managing book purchases and transactions.
- •	User Database: To manage user accounts and preferences.
 
## Functional Requirements
**Requirement 100.0: Search for Books**
Scenario: As a user interested in self-help literature, I want to search for books by title, author, or keywords, so that I can easily find books that resonate with my personal journey.
### Dependencies
- •	Book data is available and accessible via OpenLibrary API.
- •	The search functionality must be user-friendly.
Assumptions
- •	Book titles and authors are accurately listed in the database.
***Examples 1.1***
Given a feed of book data is available
When I search for " Brené Brown"
Then I should receive results that include:
- •	Title: "Daring Greatly" ;  “Dare To Lead”
- •	Author: Brené Brown
- •	Genre: Personal Development
- •	Rating: 4.06 stars
- •	Reviews Count: 907
**Requirement 101.0: Viewing Book Details**
Scenario As a user, I want to view detailed information about a book, including its genre, author details, and ratings, so that I can make informed reading choices.
Dependencies
- •	Book data is accessible via the OpenLibrary API.
Assumptions
- •	Users will be interested in comprehensive details before making a purchase.
****Examples 1.1***
Given I select a book titled "Who Moved My Cheese"
When I view the book details page
Then I should see:
- •	Title: Who Moved My Cheese
- •	Author: Spencer Johnson
- •	Genre: Change Psychology 
- •	Average Rating: 3.8 stars
- •	Reviews Count: 73

**Requirement 102.0: YouTube Integrations**
Scenario: As a user, I want to access video content related to self-help and physical fitness books and topics, so that I can enhance my understanding through multimedia resources.
Dependencies
- •	Access to the YouTube API for video content.
Assumptions
- •	Users enjoy consuming content in various formats.
***Examples 1.1***
Given I am on the details page for "The Gifts of Imperfection"
When I scroll to the YouTube section
Then I should see embedded videos, including:
- •	Video Title: "Brené Brown: The Power of Vulnerability"
- •	Duration: 20 minutes
**Requirement 103.0: User Account Management**
Scenario As a user, I want to manage my account settings, including my profile information, reading history, and preferences, so that I can personalize my experience.
Dependencies
- •	A secure user database for managing account information.
Assumptions
- •	Users value the ability to customize their experience.
***Examples 1.1***
Given I am logged into my account
When I navigate to the Account Settings page
Then I should see options to:
- •	Edit Profile: Update my name, email, and password.
- •	Reading Preferences: Select genres of interest.
- •	Reading History: View and manage my past readings.
**Requirement 104.0: User Reviews**
Scenario As a user, I want to write and read reviews for books, so that I can share my insights and benefit from the experiences of others.
Dependencies
- •	Users must be logged in to submit reviews.
Assumptions
- •	Users are willing to engage with the community through reviews.
***Examples 1.1***
Given I am logged into my account
When I read "Atomic Habits"
Then I should be able to submit an anonymous review that includes:
- •	Rating: 5 stars
- •	Comment: “Incredibly actionable advice!”
***Examples 1.2***
Given I am viewing the book details for "The Subtle Art of Not Giving a F*ck"
When I scroll to the reviews section
Then I should see a list of user reviews, including:
- •	Rating: 4 stars
- •	Comment: “A refreshing take on living authentically.”
 
## Scrum Roles
- •	**DevOps/Product Owner/Scrum Master**: Deepika Srivastava
- •	**Frontend Developer**: Vaishnovi Palaparthy, Abhishek Badola
- •	**Integration Developer**: Kanchan Joshi, Yash Bheke
  
## Weekly Meeting
Thursday at 11am on Teams
