# Assignment 6 - Web Application to Manage Beverages

## Author



## Description

You are to create a web application using ASP.NET Core MVC to manage our beverage database.
The application should have the following pages and navigation:

A Home page that is not the default. Does not have to be fancy but different than the default.

A Privacy page that is not the default. Does not have to be fancy but different than the default.

A Contact page. Does not have to be fancy.

A Beverages page that can only be seen when the user is logged in.

Other CRUD related pages to augment the Beverages page.

All of the built in user account pages (Login, Register, etc.).

Every view must use a Master Layout file for the things that do not change.

The Home page should have a nice welcome page that helps a new user figure out how to use the site without being as 
overly detailed as the About page. This will more or less be a static page.

The Privacy Page should include some information about the privacy practices of your application.
You may want to include some information about what Cookies you are storing and why. This will also be more or less a static page.

The Contact Page should provide a way for users of the site to contact you if they have questions or concerns about 
the site. This can be made up information. This will also be more or less be a static page.

The Beverages page is where the main focus of the site should be.

Once a user is registered and logged in, they will be able to see navigation links to reach this page. If they try 
to navigate directly to this page without being logged in, it should redirect them to the login or register page.

The Beverages page should list all of the beverages stored in the same database as what was used for assignment 5. 
The information to connect is listed below in case you forgot. In addition to the page displaying the list of items, 
there should be links for each item that allows the user to update or delete a specific item from the list. This 
will require the creation of additional pages to implement the functionality.

There should also be a way to create a new item to be added to the beverages database. This will require an 
additional page to implement the functionality.

At the top of the Beverages list page there should be a filter that can be used to filter the contents of the 
beverages list. Filter fields should include Name, Pack, Min Price, and Max Price. There should be a button in the 
filter section to submit the filter. Submitting the filter will cause the application to store the filter 
information in the session, and then use that information to display a filtered version of the data in the database. 
Once data is entered for the filter, the input boxes for the filter should reflect what was entered. Meaning that 
after the filter is applied, the user can see what they filtered on. Don't let the input boxes go back to blank.

It is okay to use scaffolding to create Views, however you may need to then go in and tweak Views to add more 
functionality to them. (Filter)

The Login information for users will be stored in a localdb, and the Beverage information will be stored in the same 
remote database we used in the previous assignment. Just so it is clear, the application will be using 2 databases.

The EntityFrameworkCore Models that are created for the Beverages, and the ones that .NET Core provides for user 
authentication will make up the Models portion of MVC.

You must create your own Controller for handling the work of maintaining the Beverages and dealing with any pages 
related to maintaining the beverages. This will be the Controller portion of MVC.

You must create any Views that you need to for handling the work of maintaining the Beverages. This includes the list 
of beverages and views to add, update, and delete. This will be the View portion of MVC.

When creating a new beverage, the user must be able to enter in the id for the beverage. When updating a beverage, 
the user should NOT enter in the id. Since the id is a primary key, users should be unable to change that.
The list of updatable fields are as follows:

* Description
* Pack
* Price
* Active

Here is a reminder of how to connect to your Beverage Database.

To connect to the database you will use the following information.

Sever address / name: barnesbrothers.ddns.net,443 //Remember that the comma denotes that the port number follows.

Sql Server Authentication (Not Windows Auth):

Username: FirstInial + LastName (All lowercase) (ie. John Smith would be jsmith)

Password: password (If you would like me to change your password to something else for you, I can)

DatabaseName: Beverage + FirstInital + LastName

********************************************************************************************
*NOTE: There is a database for each person. Use the one that is for you. Don't be a troll. If I hear about you trolling on someone else's database, you will get a zero for the assignment!
********************************************************************************************

### Solution Requirements:

* 4 Main pages: Home, Privacy, Contact, and Beverages
* Beverages must be augmented by any additional needed pages to perform CRUD
* Master Layout page
* Pages for user authentication and account setup
* EntityFramework Model and Collection
* Read functionality
* Insert functionality
* Update functionality
* Delete functionality
* Filter on the list of beverages that will filter the results on the page
* Denied access to beverages page for non-logged in users.

### Extra Credit
You can get up to 40 assignment points of extra credit by adding additional functionality (Max 8 points per feature). If you attempt any of this extra credit, be sure to add a section to this README stating what Extra Credit you are attempting. Otherwise, I may not know to look for it. The extra credit can be obtained by adding the following features:

* Validate all information that is submitted to ensure it is valid. This includes Insert, Update, and Filtering of Beverages.
* Use JavaScript / jQuery to handle getting to the edit page of a item in the list by setting a click listener on the table row for the item. (This would replace the edit link from scaffolding)
* Use JavaScript / jQuery to pop up a confirmation delete message when deleting a beverage. (I realize that there is already a delete check, but I want a JS one for the Extra Credit)
* Ability to click on a table header and sort the list of items by that column. You must do at least 2 column headings.
* Write at least 2 unit tests to verify your code.

### Notes

There is a Microsoft Written Tutorial that might help you.

This one is okay, and it is from Microsoft:
[Microsoft](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-5.0&tabs=visual-studio)

The following Bootstrap documentation should help you figure out how to add some simple styling to your project if interested. In addition, you may be able to find an entire Bootstrap theme that you could include to really make it look good.
[Bootstrap](https://getbootstrap.com/docs/4.6/getting-started/introduction/)

## Grading
| Feature                                 | Points |
|-----------------------------------------|--------|
| EF Models                               | 10     |
| Insert Functionality                    | 5      |
| Update Functionality                    | 5      |
| Delete Functionality                    | 5      |
| List All                                | 5      |
| Filter                                  | 15     |
| Master Page                             | 5      |
| CRUD Pages                              | 15     |
| Update Default Pages                    | 10     |
| Auth Protection Beverages               | 15     |
| Documentation                           | 5      |
| README                                  | 5      |
| **Total**                               | **100**|

## Outside Resources Used



## Known Problems, Issues, And/Or Errors in the Program


