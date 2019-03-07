# ElevenNote
A basic note taking app that demonstrates the basics of an n-tier application. This project was built out using the Web MVC pattern in ASP.NET. The Web MVC pattern was selected as the base template to build off of but in order to set up the n-tier pattern we moved the IdentityModels.cs file into the ElevenNote.Data layer. This was done to ensure that once the Api was completed, it would have access to the same user accounts and datatables as the Web MVC. This also required us to add references in the MVC project to the ElevenNote.Data layer to be able to call on those methods. 
