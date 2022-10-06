Client (Person) Makes a company registeration request to the (WebApp).

The (WebApp) sends a request to the (API) to create a new company.

The (API) creates a new company and returns the company ID to the (WebApp).

The packets in this procedure are the following:

-RegisterCompanyRequest [Contains the company fields]

-RegisterCompanyCommand [Contains the company fields + the company ID]

-RegisterCompanyCommandHandler [Handles the RegisterCompanyCommand]

-RegisterCompanyResult [Contains the company ID]

-RegisterCompanyResponse [Contains the company ID]

Two different ways to implement this procedure:

1. We store the http packets in separate project called "CyberTutorial.Contracts" and use them in the (WebApp) and (API) projects, the packets 
are related for "Request" and "Response". These packets should be declared without any dependencies to the other projects.

2. We store commands, commands handlers and results in the (API) project. The incoming "Request" will be mapped directly to the command
and the command handler will process the command and return the result which will be mapped to the "Response" packet.

This is happening because we have two separate projects for the (WebApp) and (API) and we want to use the same packets in both projects.

In Authentication (Login) the possible erros are:
1. Invalid Password.
2. Email Does not exists.
3. Validation Errors (Email is required, Password is required, etc).

In Registration (Company) the possible erros are:
1. Email already exists.
2. Company with given Id does not exists.
3. Validation Errors (Email is required, Password is required, etc).

In Registration (Employee) the possible erros are:
1. Email already exists.
2. Employee with given Id does not exists.
3. Validation Errors (Email is required, Password is required, etc).