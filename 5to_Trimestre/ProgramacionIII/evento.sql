


/* TRIGGERS o Disparadores */
CREATE TRIGGER TR_ProductoInsertado
ON productos for INSERT
AS
INSERT INTO histotial values(getdate(), 'resgistro insertado', SYSTEM_USER)
go

