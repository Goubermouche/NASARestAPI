# Functional Specification
## Nasa Image Viewer

Version 0.1  
Prepared by Simon Tupý 4.C  
SSPŠaG  
October 10, 2022

Table of Contents
================
* 1 [Introduction](#1-introduction)
   * 1.1 [Document Purpose](#11-document-purpose)
   * 1.2 [Definitions, Acronyms and Abbreviations](#12-definitions-acronyms-and-abbreviations)
   * 1.3 [Target Audience](#13-target-audience)
   * 1.4 [References](#14-references)
* 2 [Scenarios](#2-scenarios)
   * 2.1 [Usecases](#21-usecases)
   * 2.2 [Personas](#22-personas)
   * 2.3 [Details, Motivation and Live Examples](#23-details-motivation-and-live-examples)
   * 2.4 [Product Scope](#24-product-scope)
   * 2.5 [Unimportant Functions and Properties](#25-unimportant-functions-and-properties)
* 3 [Architecture Overview](#3-architecture-overview)
   * 3.1 [Work Flow](#31-work-flow)
   * 3.2 [Main Modules](#32-main-modules)
   * 3.3 [Details](#33-details)
   * 3.4 [Possible Program Flows](#34-possible-program-flows)

## 1. Introduction  
  ### 1.1 Document Purpose
  The purpose of this document is to present a description of the functions and interfaces of the final product. Furthermore, it will introduce and discuss commonly used concepts, interfaces and usecases, including a basic overview of the application's structure and inner workings.
  ### 1.2 Definitions, Acronyms and Abbreviations
| Term | Definition    |
| ---- | ------- |
| Software Requirements Specification  |  A document that completely describes all of the functions of a proposed system and the constraints under which it must operate. For example, this document.       |
| API | Application program interface |
  ### 1.3 Target Audience
This document is intended mainly for testers, developers, the marketing department, and other parties that may be involved. 
  ### 1.4 References
* Software Requirement Specification *Šimon Tupý* https://github.com/Goubermouche/Color-Picker/blob/main/SRS.md    
* images.nasa.gov API Documentation *Nasa* https://images.nasa.gov/docs/images.nasa.gov_api_docs.pdf
* Nasa *USA* https://www.nasa.gov/
* Nasa Open Apis *Nasa* https://api.nasa.gov/
* Xamarin forms *Microsoft* https://dotnet.microsoft.com/en-us/apps/xamarin/xamarin-forms
* Android https://www.android.com/
* Newtonsoft JSON https://www.newtonsoft.com/json
## 2. Scenarios
  ### 2.1 Usecases
The main use case of the product is viewing images retrieved from the nasa.images API.
  ### 2.2 Personas
The products target audience mainly consists of enthusiasts interested in images related to NASA and its various space ventures. 
  ### 2.3 Details, Motivation and Live Examples
N/A
  ### 2.4 Product Scope
The application will be able to perform basic search operations on the images.nasa API, and then display the resulting images. Furthermore the application will also save the last search result. Below you can see a simple diagram of what the final application might look like: 

<p align="center">
  <img src="https://github.com/Goubermouche/NASARestAPI/blob/master/Documents/Group%201.png" />
</p>

  ### 2.5 Unimportant Functions and Properties
The application will contain a basic search bar containing a simple 'X' button that will clear the underlying entry once clicked, the 'X' button will only be visible if the underlying entry contains atleast one character. 

## 3. Architecture Overview
  ### 3.1 Work Flow
 Once the application launches the user will be presented with a simple UI containing a search bar and a list view containing the latest search results, if any are available. The user can then use the searchbar to access images from the images.nasa image gallery, after inputting a search query the user can then press the 'search' button on their keyboard to confirm the search and send a request. Once a search request is sent and received the data will begin downloading, the download progress will be displayed inside a simple progress bar located underneath the search bar. After the data is successfully retrieved it will be displayed inside the list view. 
 
  ### 3.2 Main Modules
The application contains three main modules: an image viewer module, that visualizes and manages the image context, the search module, and the serialization module. Below you can see the possible program flows between the several modules. 

<p align="center">
  <img src="https://github.com/Goubermouche/NASARestAPI/blob/master/Documents/diagram.png" />
</p>

  ### 3.3 Details
The application will only run on android (Oreo+).
  ### 3.4 Possible Program Flows
The application has two main program flows: the first one describes a situation where the user opens the application and then views their latest search query that was retreived from local storage, if one is available. The second program flow describes a situation where the user opens the application and then proceeds to send a search query using the search bar. 
