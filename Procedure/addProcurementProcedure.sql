CREATE DEFINER=`root`@`localhost` PROCEDURE `addProcurement`(
	in date datetime,
    in UserId integer,
    in ProcurerId integer,
    in Art1Id integer,
    in Art2Id integer,
    in Art3Id integer
)
BEGIN
	DECLARE totPrice DECIMAL(10,2) DEFAULT 0.00;
    DECLARE currPrice DECIMAL(5,2);
    DECLARE newProcurementId INT;
    DECLARE i INT DEFAULT 1;
    
	INSERT INTO Procurement (Date, TotalPrice, User_idUser, Procurer_idProcurer)
    VALUES (date, 0.00, UserId, ProcurerId);
    
    SET newProcurementId = LAST_INSERT_ID();
    
    SELECT ProcurementPrice into currPrice from article where idArticle= Art1Id;
    INSERT INTO ProcurementItem (Quantity, Price, Article_idArticle, Procurement_idProcurement)
	VALUES (5, currPrice, Art1Id, newProcurementId);
	SET totPrice = totPrice + (currPrice * 5);
    
    SELECT ProcurementPrice into currPrice from article where idArticle= Art2Id;
    INSERT INTO ProcurementItem (Quantity, Price, Article_idArticle, Procurement_idProcurement)
	VALUES (5, currPrice, Art2Id, newProcurementId);
	SET totPrice = totPrice + (currPrice * 5);
    
    SELECT ProcurementPrice into currPrice from article where idArticle= Art3Id;
    INSERT INTO ProcurementItem (Quantity, Price, Article_idArticle, Procurement_idProcurement)
	VALUES (5, currPrice, Art3Id, newProcurementId);
	SET totPrice = totPrice + (currPrice * 5);
    
	UPDATE Procurement SET TotalPrice = totPrice WHERE idProcurement = newProcurementId;
END