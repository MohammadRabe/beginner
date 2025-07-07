I made the code satisfied to SRP by making sure that every class has only one responsibility : 
Api classes => to notify the assistant
Databases => save To Database
EmailSenders => to Send a msg
Alert classes => to SendAlert

etc .....

To satisfy OCP : 
- i generalized Api concept not just being GoogleHomeApi 
in case in the future there is a new api
- same with Database, EmailSender , AlertSender, monitor and SmartManager

To satisfy LSP :
- i made sure that every child class really uses its parent methods

To satisfy ISP :
- Each class only implements interfaces that has the methods it uses  
- as we see with IDatabase, IApi and ISender

To satisfy DIP :
- any class that plays the role of a high-level module deals with abstraction not a designated type
- that appears in the class DeviceController in which it uses only abstractions either abstract classes or interfaces 
so that a controller is flexible to controll whatever type of device notify whomeever assistant and save the state
to whichever database

