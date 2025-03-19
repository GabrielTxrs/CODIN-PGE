USE `CODIN` ;

CREATE TABLE `TB_USUARIO` (
  `ID_USUARIO` INT NOT NULL,
  `DS_EMAIL` VARCHAR(60),
  `TOKEN` VARCHAR(1000),
  PRIMARY KEY (`ID_USUARIO`)
  );

CREATE TABLE `TB_ADVOGADO` (
  `ID_ADVOGADO` INT NOT NULL,
  `ID_USUARIO` INT,
  `IS_PROCURADOR` TINYINT,
  `OAB` VARCHAR(1000) NOT NULL,
  `NM_PESSOA_FISICA` VARCHAR(100),
  `NM_SOCIAL` VARCHAR(100),
  `NR_CPF` VARCHAR(11),
  `NR_CELULAR` VARCHAR(20),
  `NR_TELEFONE` VARCHAR(25),
  `EMAIL` VARCHAR(60),
  `DT_NASCIMENTO` DATE,
  PRIMARY KEY (`ID_ADVOGADO`),
  CONSTRAINT `FK_USU_ADV_ID_USUARIO` FOREIGN KEY (`ID_USUARIO`) REFERENCES `TB_USUARIO` (`ID_USUARIO`)
);

CREATE TABLE `TB_PROCESSO` (
  `ID_PROCESSO` INT NOT NULL,
  `ID_PROCURADOR` INT,
  `DT_CRIACAO` TIMESTAMP,
  `DT_CONCLUSAO` TIMESTAMP,
  `STATUS_PROCESSO` VARCHAR(100),
  `TRAMITACAO` VARCHAR(500),
  PRIMARY KEY (`ID_PROCESSO`),
  CONSTRAINT `FK_ADV_PRO_ID_ADVOGADO` FOREIGN KEY (`ID_PROCURADOR`) REFERENCES `TB_ADVOGADO` (`ID_ADVOGADO`)
);

CREATE TABLE `TB_CLIENTE` (
  `ID_CLIENTE` INT NOT NULL,
  `ID_USUARIO` INT,
  `NM_PESSOA_FISICA` VARCHAR(100),
  `NM_SOCIAL` VARCHAR(100),
  `NR_CPF` VARCHAR(11),
  `NR_CELULAR` VARCHAR(20),
  `NR_TELEFONE` VARCHAR(25),
  `EMAIL` VARCHAR(60),
  `DT_NASCIMENTO` DATE,
  PRIMARY KEY (`ID_CLIENTE`),
  CONSTRAINT `FK_USU_CLI_ID_USUARIO` FOREIGN KEY (`ID_USUARIO`) REFERENCES `TB_USUARIO` (`ID_USUARIO`)
);

CREATE TABLE `TB_APC_ADVOGADO_PROCESSO_CLIENTE` (
  `ID_ADVOGADO_PROCESSO_CLIENTE` INT NOT NULL,
  `ID_ADVOGADO` INT,
  `ID_PROCESSO` INT,
  `ID_CLIENTE` INT,
  PRIMARY KEY (`ID_ADVOGADO_PROCESSO_CLIENTE`),
  CONSTRAINT `FK_ADV_APC_ID_ADVOGADO` FOREIGN KEY (`ID_ADVOGADO`) REFERENCES `TB_ADVOGADO` (`ID_ADVOGADO`),
  CONSTRAINT `FK_PRO_APC_ID_PROCESSO` FOREIGN KEY (`ID_PROCESSO`) REFERENCES `TB_PROCESSO` (`ID_PROCESSO`),
  CONSTRAINT `FK_CLI_APC_ID_CLIENTE` FOREIGN KEY (`ID_CLIENTE`) REFERENCES `TB_CLIENTE` (`ID_CLIENTE`)
);

CREATE TABLE `TB_DOCUMENTO` (
  `ID_DOCUMENTO` INT NOT NULL,
  `TIPO_DOCUMENTO` VARCHAR(45),
  `CAMINHO_DOCUMENTO` VARCHAR(500),
  `NM_DOCUMENTO` VARCHAR(100),
  `DS_DOCUMENTO` VARCHAR(1000),
  `DT_CRIACAO` TIMESTAMP,
  `CD_DOCUMENTO` INT,
  PRIMARY KEY (`ID_DOCUMENTO`)
);

CREATE TABLE `TB_AT_ATUALIZACAO_PROCESSO` (
  `ID_ATUALIZACAO_PROCESSO` INT NOT NULL,
  `ID_DOCUMENTO` INT,
  `ID_PROCESSO` INT,
  `DS_ATUALIZACAO` VARCHAR(3000),
  `DT_ATUALIZACAO` TIMESTAMP,
  `TRAMITACAO` VARCHAR(500),
  `TB_AT_ATUALIZACAO_PROCESSOcol` VARCHAR(45),
  PRIMARY KEY (`ID_ATUALIZACAO_PROCESSO`),
  CONSTRAINT `FK_DOC_AT_ID_DOCUMENTO` FOREIGN KEY (`ID_DOCUMENTO`) REFERENCES `TB_DOCUMENTO` (`ID_DOCUMENTO`),
  CONSTRAINT `FK_PRO_AT_ID_PROCESSO` FOREIGN KEY (`ID_PROCESSO`) REFERENCES `TB_PROCESSO` (`ID_PROCESSO`)
);

CREATE TABLE `TB_PRAZO` (
  `ID_PRAZO` INT NOT NULL,
  `ID_PROCESSO` INT,
  `TIPO_PRAZO` VARCHAR(45),
  `DT_INICIO` TIMESTAMP,
  `DT_FIM` TIMESTAMP,
  PRIMARY KEY (`ID_PRAZO`),
  CONSTRAINT `FK_PRO_PRAZO_ID_PROCESSO` FOREIGN KEY (`ID_PROCESSO`) REFERENCES `TB_PROCESSO` (`ID_PROCESSO`)
);