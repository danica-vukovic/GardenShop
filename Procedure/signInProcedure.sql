CREATE DEFINER=`root`@`localhost` PROCEDURE `signIn`(in u_username varchar(45), in u_password varchar(45), out u_signIn boolean, out u_idUser int, out u_name varchar(45),  out u_surname varchar(45),  out u_phoneNumber varchar(45),  out u_isAdmin boolean,  out u_language int, out u_theme int, out u_active boolean)
BEGIN
	SELECT count(*)>0, idUser, Name, Surname, PhoneNumber, isAdmin, Language, Theme, Active 
    INTO u_signIn, u_idUser, u_Name, u_Surname, u_PhoneNumber, u_isAdmin, u_language, u_theme, u_active FROM user u
	WHERE u.username=u_username AND u.password=u_password
    group by idUser, Name, Surname, PhoneNumber, isAdmin;
END