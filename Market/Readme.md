# Package Manager Console 
### Update Migration 
- to make migration update classes and files -> ` add-migration IntialMigration `
- to Execute                                 -> ` update-database `


# DB Command
//list the instancies
` sqllocaldb i `

//stop selected instance
` sqllocaldb p "selected instance" `

//delete
` sqllocaldb d "selected instance" `
> You need to delete file C:/Users/{PC Name}/AppName.mdf

//recreate or create new one 
` sqllocaldb c "new instance" `
