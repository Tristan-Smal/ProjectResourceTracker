# Resource Tracker

A simple web app to track which resources were used when creating a project

<h3>Summary of new concepts and skills learned through this project:</h3>
<ul>
    <li>SOLID principles</li>
    <li>How to create a web app using ASP.NET Core</li>
    <li>How to use Visual Studio</li>
</ul>

<h2>SOLID Principles</h2>
<h3>What are the SOLID principles?</h3>
<p>The solid principles were developed by Robert C. Martin to make object-oriented designs more understandable, flexible, and maintainable.</p>
<ul>
    <li>S: Single Responsibility Principle</li>
    <li>O: Open-Closed Principle</li>
    <li>L: Liskov Substitution Principle</li>
    <li>I: Interface Segregation Principle.</li>
    <li>D: Dependency Inversion Principle.</li>
</ul>

<h3>What is the Single Responsibility Principle and why is it used?</h3>
<p>
    This principle is effectively summarised by Robert Martin, who states that a class should have one, and only one, reason to change. Adhering to this principle requires that every class or module is responsible for a single aspect of the software's functioning and does not perform multiple functions.
</p>
<p>
    This straightforward yet helpful principle helps to prevent potential bugs, which saves the developer time and effort. By adhering to this principle, future modifications are less likely to have unanticipated side effects and the software will be easier to deploy, test, and maintain.
</p>

<h3>What is the Open-Closed Principle and why is it used?</h3>
<p>
    The open-closed principal deals with adding code to a project. This principle addresses how code should be written so as to avoid the need to modify existing code, as doing so can result in errors or unforeseen bugs. This principle can be followed by writing code that meets two criteria:
</p>
<ul>
    <li>Open to extension, which means that the functionality of the class can be extended.</li>
    <li>Closed for modification, which means that the source code cannot be modified.</li>
</ul>
<p>
    Using abstractions is the best way to adhere to these guidelines and ensure that your class can be easily extended without requiring code modifications. One common approach to adhere to this principle is through inheritance or interfaces that support polymorphic substitutions. To write code that can be reviewed 
    and maintained, it is crucial to conform to this principle, regardless of the approach taken.
</p>

<h3>What is the Liskov Substitution Principle and why is it used?</h3>
<p>
    The essence of Liskov's substitution principle is to enforce that every derived class has the ability to be substituted for its parent class. The principle is named after Barbara Liskov, who introduced the idea of behavioural subtyping in 1987. Liskov explains the principle by saying:
</p>
<p>
    “What is sought here is something like the following substitution property: if for every object O1 of type S there exists an object O2 of type T such that for all programs P defined in terms of T, the behaviour of P does not change when O1 is replaced by O2, then S is a subtype of T.”
</p>
<p>
    Although this principle might seem complicated at first, it is really just an expansion of the open-closed principle, since it ensures that derived classes extend the base class without altering its behaviour. Following this principle keeps changes from having unanticipated repercussions and prevents opening a closed class in order to implement changes.
</p>

<h3>What is the Interface Segregation Principle and why is it used?</h3>
<p>
    One way to sum up the general idea behind the interface segregation principle is that having many small interfaces is preferable to having a few large ones.
</p>
<p>
    In order to convey this idea, Martin suggests that developments concentrate on creating precise interfaces for particular user needs rather than requiring the user to comply with the interface's demands. When working with smaller interfaces developers should favour composition over inheritance and decoupling over coupling.
</p>
<p>
    Martin explains this principle by advising that developments should focus on fine-grained interfaces, for specific customer functions, without having to force the customer to use the interface. Smaller interfaces mean that developers should prefer composition over inheritance and decoupling over coupling.
</p>

<h3>What is the Dependency Inversion Principle and why is it used?</h3>
<p>
    This principle offers a method to separate software modules. According to the dependency inversion principle, developers should depend on abstractions rather than concretions.  Although there are other approaches as well, using a dependency inversion pattern is a common way to adhere to this principle.
</p>
<P>
    Regardless of the approach you take, applying this principle will increase the flexibility, agility, and reusability of your code.
</P>

<h2>How were the SOLID principles applied in this project?</h2>
<h3>Single Responsibility</h3>
<p>
    In the extract of code shown in the image below the “GET: Projects” section is responsible for calling the HTML page which displays all the projects the user has created, the “GET: Projects/Create” section is responsible for calling the HTML page which allows the     user to enter the title and description of the new project they would like to create. Finally, the “POST: Projects/Create” section is responsible for adding the title and description of the newly created project to the projects database. From this it is clear         each class is responsible for exactly one part of the web app’s functionality.
</p>

![single_resposibility_image](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/31f2f139-2a79-41a3-ac86-b36de93467f7)

<h3>Open-Closed</h3>
<p>
    This project complies with the open-closed principle even though no extensions were made because the current code is open for extensions but closed for modification. This code excerpt, which comes from the model's folder, is the Project constructor. 
</p>

![open-closed_image](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/ed81cca1-7e0b-4463-94ef-e9fc4712018a)

<p>
    Although the class currently performs all necessary functions, it is entirely possible to expand the class in the event that additional features or modifications are required. going over an example of incorporating a note-adding feature into the project. To avoid     any unexpected errors or bugs, it is recommended to extend the class rather than making changes directly to the Project constructor. As can be seen in the sample code extract below, we extend the Project class by following the open-closed principle.
</p>

![open-closed_image2](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/06ed283d-f2db-4891-b6d6-4ba3f617b9b5)


<h3>Liskov substitution</h3>
<p>
    Since inheritance was not necessary for this fairly simple project Liskov's substitution principle was not applied. I will, however, I will go over an example of how Liskov’s substitution principle should be applied in the future for any project improvements or modifications.
</p>
<p>
    Consider the following ResourceCollection interface which can be implemented to create any type of resource collection class.
</p>

![liskov_substitution_image](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/fe5116de-0929-4e93-9747-f4a0b8a68195)

<p>
    The above example violates the Liskov Substitution principle because the ReadOnlyResourceCollection class implements the ResourceCollection interface, but throws a NotImplementedException for two methods Add() and Remove(). The ReadOnlyResourceCollection class is for the read-only collection thus you cannot add or remove any item. Liskov Substitution principle states that the subtype must be substitutable for the base class or base interface. In the above example, another interface should be created for read-only collection without Add() and Remove() methods.
</p>

<h3>Interface Segregation</h3>
<p>
    The interface for the project is separated into smaller interfaces, instead of having one large interface that controls every action that can be performed on a project. Looking at an example project from the projects tab in the web app. The actions that can be carried out on any project indicated in red, all have separate interfaces.
</p>

![interface_segregation_image1](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/7ef62c1a-60f4-489b-a468-9cbcafe6dfd9)

<p>
    Instead of having one large interface such as:
</p>

![interface_segregation_image2](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/9bd4ebfc-d5b3-40b7-b5da-0c609a176564)

<p>
    The interface for the project actions is still separated as follows even though an interface method was not explicitly used in this project.
  
![interface_segregation_image3](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/9a357914-05e4-47d0-904b-4b733e865680)
    
![interface_segregation_image4](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/b370defe-0aed-4845-9daf-906f2d5c8fde)

![interface_segregation_image5](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/43f119b0-80fa-4ea4-88bc-e98a4ae76d59)

![interface_segregation_image6](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/116aa93b-9721-498a-9d7f-622ef50fdd08)


<h3>Dependency Inversion</h3>
<p>
    This project adheres to the dependency inversion principle by ensuring that all the classes depend on abstractions rather than concretions.
</p>

![dependency_inversion_image](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/e58f09d7-b21b-48a5-8c27-d7441ef77adb)

![dependency_inversion_image1](https://github.com/Tristan-Smal/ResourceTracker/assets/100513296/906bc4fd-3e6c-4504-ac0a-35e61415ee1a)

<p>
    It is evident from the code extracts showing the project constructor and the code to create a new project and post it to the database that the high-level modules are independent of the low-level modules and rely on abstraction rather than concretions.
</p>
