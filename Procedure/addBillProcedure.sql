CREATE DEFINER=`root`@`localhost` PROCEDURE `addBill`(
	in date datetime,
    in UserId integer,
    in ArtId1 integer,
    in ArtId2 integer,
    in ArtId3 integer
)
BEGIN
	DECLARE totPrice DECIMAL(10,2) DEFAULT 0.00;
    DECLARE currPrice DECIMAL(5,2);
    DECLARE newBillId INT;
    DECLARE i INT DEFAULT 1;
    
	INSERT INTO Bill (Date, TotalPrice, User_idUser)
    VALUES (date, 0.00, UserId);
    
    SET newBillId = LAST_INSERT_ID();
    
	SELECT SalePrice into currPrice from article where idArticle= ArtId1;
    INSERT INTO BillItem (Quantity, Price, Bill_idBill, Article_idArticle)
	VALUES (3, currPrice, newBillId, ArtId1);
	SET totPrice = totPrice + (currPrice * 3);
    
   	SELECT SalePrice into currPrice from article where idArticle= ArtId2;
    INSERT INTO BillItem (Quantity, Price, Bill_idBill, Article_idArticle)
	VALUES (3, currPrice, newBillId, ArtId2);
	SET totPrice = totPrice + (currPrice * 3);
    
 	SELECT SalePrice into currPrice from article where idArticle= ArtId3;
    INSERT INTO BillItem (Quantity, Price, Bill_idBill, Article_idArticle)
	VALUES (3, currPrice, newBillId, ArtId3);
	SET totPrice = totPrice + (currPrice * 3);
    
    UPDATE Bill SET TotalPrice = totPrice WHERE idBill = newBillId;
END