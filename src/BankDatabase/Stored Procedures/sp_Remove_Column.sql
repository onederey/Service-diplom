﻿
CREATE PROCEDURE sp_Remove_Column
AS
ALTER TABLE CUSTOMER
DROP COLUMN CustomerAddress1;
