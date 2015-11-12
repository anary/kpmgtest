# kpmgtest

#Summary:
The project is designed with four layers.  Core, Data, DataProcess(business logic), KPMGTest.
Core layer: defined all the public interface and entities.
Data: implemented DAL and CSV reader.
DataProcess: implemented business logic.
KPMGTest: asp.net MVC structure.

#Database:
It designed with Entity Framework code first. It leverages DAL generic Repository and unitOfWork design pattern.  I used the localdb as persistence database, which can be set as any other kind, which is set in web.config.

#File:
File is supported by XLSX and CSV only.


#UI:
As time limited, I just did the basic function of the requirement. The better practise should be fulfilled with JQuery to make asynchronous request and response. 


Thanks!
