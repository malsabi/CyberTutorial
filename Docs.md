TODO LIST:
1. Improve UI login by removing Checkbox, and add a label for if the user forgot his password. (done)
2. Upgrade login feature by adding user sessions in the database. (done)
3. Change the JWT Token to be valid for 30 days only same as the cookies. (done)
4. Implement logout feature. (done)
5. After the company owner or employee logins, there current page should be shown and a log out button also. (done)
6. Improve login response by removing unnecessary properties from the response class and add only token and session id. (done)
7. API Optimization (for register controller: api/Register only)

TODO LIST:

1. Design register page for company owner and employee. (done)
2. Improve WebApp Services (CookieService) (done)
4. Handle home page and other pages to not be visible when the employee or company owner is logged in. (done)
5. Create custom layout for employee and company owner. (done)
6. add methods for validating the session, etc. (done)


TODO LIST:
1(a). Add Data Annotations for company and employee models. (done)
1(b). Remove unneccassry validations for company and employee request messages in app layer. (done)

2. Improve Responses from API to WebApp. (done)
3(a). Handle the sign up button for company and employee in the JS side. (done)
3(b). Based on the response we will show a toast that will contain the response message. (done)
3(c). If the response message is successful, we will show a success modal that will contain an image and a message and after the user closes the success modal
it will pop up the login modal, if the user goes back to sign up modal, all of the data will be cleared. (done)

EXTRA TIPS:
1. Improve login response, that will contain an indication of success and which page to be navigated to, eg: CompanyProfile, EmployeeProfile. and based on these
dataa the JS will do the right procedure. (done)

2. Refactor HomeController add all of the logic inside the actions into IdentityService and based on that service we can call the methods, so our controller 
can be clean. (done)

3. Encrypt the token before storing it in the cookies. (done)


TODO LIST:

1. Add a general response from webapp to client, instead of depending on object type.


TODO LIST:
1. Finish Employee Page design => Courses, Quizzes, Library, Profile, Settings.
2. Implement the features and add the important entities to the database. (done)
3. (HOT FIX) If the cookie is still exists in the client side, make sure also to validate that the session Id and Token still exists in the database. (done)
4. Move Registeration to Authentication Controller. (done)
5. Add Depdency injection for the remaining repositories. (done)
6. Add the neccassary services for employee.




