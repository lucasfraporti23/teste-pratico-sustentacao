CREATE TABLE MOTORISTA(
	Id NUMBER GENERATED BY DEFAULT AS IDENTITY,
	NOME VARCHAR(100), 
    SOBRENOME VARCHAR(100), 
    MARCA VARCHAR(100), 
    MODELO VARCHAR(100), 
    PLACA VARCHAR(100), 
    EIXOS NUMBER(10), 
    RUA VARCHAR(100), 
    NUMERO VARCHAR(20), 
    CIDADE VARCHAR(100), 
    ESTADO VARCHAR(100), 
    CEP VARCHAR(100), 
    PAIS VARCHAR(100), 
	CONSTRAINT PK_Motorista PRIMARY KEY (Id)
);

CREATE TABLE VIAGEM(
	Id NUMBER GENERATED BY DEFAULT AS IDENTITY,
	DATAVIAGEM DATE, 
    LOCALENTREGA VARCHAR(100), 
    LOCALSAIDA VARCHAR(100), 
	KM NUMBER(14,2),
    MOTORISTAID NUMBER,
	CONSTRAINT PK_Veiculo PRIMARY KEY (Id),
    CONSTRAINT FK_VIAGEM_MOTORISTA FOREIGN KEY(MOTORISTAID) REFERENCES MOTORISTA(ID)
);