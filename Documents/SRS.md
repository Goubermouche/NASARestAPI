# Software Requirements Specification
## Nasa Image Viewer

Version 0.1 - Initial proposal   
Prepared by Simon Tupý 4.C  
SSPŠaG  
May 30, 2022

Table of Contents
================
* 1 [Introduction](#1-introduction)
   * 1.1 [Document Purpose](#11-document-purpose)
   * 1.2 [Definitions, Acronyms and Abbreviations](#12-definitions-acronyms-and-abbreviations)
   * 1.3 [Target Audience](#13-target-audience)
   * 1.4 [Additional Information](#14-additional-information)
   * 1.5 [Contacts](#15-contacts)
   * 1.6 [References](#16-references)
* 2 [Product Overview](#2-product-overview)
   * 2.1 [Product Perspective](#21-product-perspective)
   * 2.2 [Product Functions](#22-product-functions)
   * 2.3 [User Groups](#23-user-groups)
   * 2.4 [Product Environment](#24-product-environment)
   * 2.5 [User Environment](#25-user-environment)
   * 2.6 [Limitations and Implementation Details](#26-limitations-and-implementation-details)
   * 2.7 [Assumptions and Dependencies](#27-assumptions-and-dependencies)
* 3 [Interface Requirements](#3-interface-requirements)
   * 3.1 [User Interface](#31-user-interface)
     * 3.1.1 [Search Bar](#311-search-bar)
     * 3.1.2 [Progress Bar](#312-progress-bar)
     * 3.1.3 [List View](#313-list-view)
   * 3.2 [Hardware Interface](#32-hardware-interface)
   * 3.3 [Software Interface](#33-software-interface)
* 4 [System properties](#4-system-properties)
   * 4.1 [Searching](#41-searching)
     * 4.1.1 [Description and Importance](#411-description-and-importance) 
     * 4.1.2 [Inputs and Outputs](#412-inputs-and-outputs) 
     * 4.1.3 [Function Specification](#413-function-specification) 
   * 4.2 [Viewing Images](#42-viewing-images) 
     * 4.2.1 [Description and Importance](#421-description-and-importance) 
     * 4.2.2 [Inputs and Outputs](#422-inputs-and-outputs) 
     * 4.2.3 [Function Specification](#423-function-specification) 
   * 4.3 [Data Serialization](#43-data-serialization) 
     * 4.3.1 [Description and Importance](#431-description-and-importance) 
     * 4.3.2 [Inputs and Outputs](#432-inputs-and-outputs) 
     * 4.3.3 [Function Specification](#433-function-specification)
  * 5 [Non-Functional Requirements](#5-non-functional-requirements)
     * 5.1 [Performance](#51-performance)
     * 5.2 [Safety](#52-safety)
     * 5.3 [Reliability](#53-reliability)

## 1. Introduction  
  ### 1.1 Document Purpose
The purpose of this document is to present a detailed description of a Nasa image library browser. It will explain the purposes, features, interface, and what the application and its accompanying systems will do and how the system will react to the user's input.
  ### 1.2 Definitions, Acronyms and Abbreviations
| Term | Definition    |
| ---- | ------- |
| Software Requirements Specification  |  A document that completely describes all of the functions of a proposed system and the constraints under which it must operate. For example, this document.       |
| API | Application program interface |

  ### 1.3 Target Audience
This document is intended for both stakeholders and the developers of the application.
  ### 1.4 Additional Information
  ### 1.5 Contacts
tupy.si.2019@skola.ssps.cz
  ### 1.6 References
* images.nasa.gov API Documentation *Nasa* https://images.nasa.gov/docs/images.nasa.gov_api_docs.pdf
* Nasa *USA* https://www.nasa.gov/
* Nasa Open Apis *Nasa* https://api.nasa.gov/
* Xamarin forms *Microsoft* https://dotnet.microsoft.com/en-us/apps/xamarin/xamarin-forms
* Android https://www.android.com/
* Newtonsoft JSON https://www.newtonsoft.com/json

## 2. Product Overview
  ### 2.1 Product Perspective
This piece of software will be a simple image gallery application that enables the user to browser and search through the images.nasa image gallery. The final product will be a simple Xamarin forms application that will run on the android operating system.
  ### 2.2 Product Functions
The application will interface with the images.nasa API. The user will have the ability to input search queries not dissimilar to a google search and the final query will be reconstructed into a WWW GET request, that will be sent over for processing.  
A short period after the user inputs a search term the resulting images and relevant data will be displayed.    
Aditionally, the application will store the last search query after the user closes the application, this query will be loaded and shown once the application starts running again. 
  ### 2.3 User Groups
There is no need for user groups, all users will have access to the same functions. 
  ### 2.4 Product Environment
The application will only run on the Android operating system (Android Oreo and above).  
  ### 2.5 User Environment
The application will provide the user with a simple one-page interface. The interface will contain a search bar, progress bar and a list view containing the images, descriptions and other information relevant to the current search query. 
  ### 2.6 Limitations and Implementation Details
Due to the limited time scope, the applications scope is also limited. The application will require stable internet access in order to achieve full functionality (the search functionality will not be available while the user is not online). 
  ### 2.7 Assumptions and Dependencies
It is expected that the user will have stable intenet access.    
The application relies on the following dependencies:   
* Newtonsoft JSON
* Xamarin Forms
  
## 3. Interface Requirements
  ### 3.1 User Interface
The application's interface will be very minimalistic - providing only a simple search bar, progress bar and list view. 
 ### 3.1.1 Search Bar
 The search bar will work as a regular entry. Additionally, a simple 'X' clear button will be provided if the search bar contains atleast 1 character, once clicked, the search bar will be cleared and unfocused. 
 ### 3.1.2 Progress Bar
 Once a search query is submitted the progress bar will display the progress of downloading the queried data. 
 ### 3.1.3 List View
 Once all the data is received, the list view will display a list of images. Each image will have its description and author/s. If there isn't an active search query or no stored data was found the list view will display a prompt instead. 

  ### 3.2 Hardware Interface
  N/A
  ### 3.3 Software Interface
  N/A

## 4. System properties
  ### 4.1 Searching
  #### 4.1.1 Description and Importance
  This feature is the core of the entire application and is closely related to the search bar. It gives our user the ability to query the images.nasa image database. 
  #### 4.1.2 Inputs and Outputs
  The user will input a basic search query (ie. "Mars"), which will then be formatted and sent via a GET request. 
  #### 4.1.3 Function Specification
  Touch-enabled display. 

  ### 4.2 Viewing Images
  #### 4.2.1 Description and Importance
After the user receives a response from the server we convert it over into a custom class-based format that is then displayed inside of a list view.
  #### 4.2.2 Inputs and Outputs
The resulting data is displayed inside of a list view. 
  #### 4.2.3 Function Specification
Display.

  ### 4.3 Data Serialization
  #### 4.3.1 Description and Importance
  Once the user closes the application and there is available search data the system will store the data and load it once the application is launched again. 
  #### 4.3.2 Inputs and Outputs
The system will take a string as the argument and store it as a property. Once the application launches again the system loads the available data, parses it, and displays it inside the image list view. 
  #### 4.3.3 Function Specification
Storage medium
## 5. Non-Functional Requirements
### 5.1 Performance
The application should work on most modern mobile devices without unnecessary lagging or stuttering. 
### 5.2 Safety
Since the application does not operate with any personal or potentially 'unsafe' or risk-prone data safety is not a concern. 
### 5.1 Reliability
The application should work perfectly, provided the user has stable access to the internet. In the case that a stable internet connection is not available the search functionality wil not be available, however, if a available, the last search result will still be visibile. 
