USE M_OpFlixFinal;

INSERT TipoUsuarios (TipoUsuario)
VALUES ('Administrador'), ('Cliente');

SELECT * FROM TipoUsuarios;

INSERT INTO Usuarios (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Erik', 'erik@email.com', '123456', 2);

INSERT INTO Usuarios (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Cassiana', 'cassiana@email.com', '123456', 1);

INSERT INTO Usuarios (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Helena', 'helena@email.com', '123456', 2);

INSERT INTO Usuarios (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Roberto', 'rob@email.com', '3110', 2);

SELECT * FROM Usuarios;

INSERT INTO Categorias(Categoria)
VALUES ('Acao'), ('Aventura'), ('Sci-Fi'), ('Fantasia'), ('Animacoes'), ('Anime'), ('Comedia'), ('Drama'), ('Horror'), ('Romanticas');

SELECT * FROM Categorias;

INSERT INTO TipoFilmesSeries (TipoFilmeSerie)
VALUES ('Filme'), ('Serie');

SELECT * FROM TipoFilmesSeries;

INSERT INTO MeiosVeiculacao (MeioVeiculacao)
VALUES ('Netflix'), ('Cinema'), ('Amazon');

SELECT * FROM MeiosVeiculacao;

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Avengers EndGame', 'Ap�s Thanos eliminar metade das criaturas vivas', 1, '200', 1, '25/04/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Avatar', 'No exuberante mundo alien�gena de Pandora vivem os Navi', 3, '162', 1, '18/12/2009');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('The Walking Dead', 'The Walking Dead conta a hist�ria de um pequeno grupo de sobreviventes de um apocalipse de zumbis', 2, '9T', 2, '31/10/2010');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Game of Thrones', 'A s�rie se inicia quando Ned Stark � convidado para se tornar o principal conselheiro', 9, '8T', 2, '17/04/2011');

SELECT * FROM Lancamentos;

INSERT INTO OndeLanca (IdFilmeSerie, IdMeioVeiculacao)
VALUES (1, 2)
	   ,(2, 2)
	   ,(3, 1)
	   ,(4, 3);

SELECT * FROM OndeLanca;

INSERT INTO MeiosVeiculacao (MeioVeiculacao)
VALUES ('Telecine Play'), ('HBO GO'), ('Google Play Filmes'), ('iTunes'), ('Now'), ('Crackle');


UPDATE Usuarios
SET IdTipoUsuario = 2
WHERE IdUsuario = 3;

UPDATE Usuarios
SET IdTipoUsuario = 1
WHERE IdUsuario = 3;

UPDATE Usuarios
SET IdTipoUsuario = 1
WHERE IdUsuario = 1;

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES (' La Casa De Papel 3 temp', 'La casa de papel � uma s�rie de televis�o espanhola do g�nero de filmes de assalto. ', 1, '3T', 2, '02/04/2017');

UPDATE Lancamentos
SET	Titulo = 'La Casa De Papel - 3� Temporada'
WHERE IdFilmeSerie = 5;

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('O Rei Le�o', 'Este desenho animado da Disney mostra as aventuras de um le�o jovem de nome Simba', 5, '118', 1, '19/07/2019');

INSERT INTO MeiosVeiculacao (MeioVeiculacao)
VALUES ('VHS');

UPDATE Lancamentos
SET	DataLancamento = '08/07/1994' 
WHERE IdFilmeSerie = 6;

INSERT INTO OndeLanca (IdFilmeSerie, IdMeioVeiculacao)
VALUES (6, 10);

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Velozes e Furiosos: Hobbs & Shaw', 'O corpulento policial Luke Hobbs se junta ao fora da lei Deckard Shaw para combater um terrorista geneticamente melhorado que tem for�a sobre-humana.', 2, '136', 1, '01/08/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Era uma Vez em... Hollywood', 'No final da d�cada de 1960, Hollywood come�a a se transformar e o astro de TV Rick Dalton e seu dubl� Cliff Booth tentam acompanhar as mudan�as.', 7, '165', 1, '15/08/2019');

INSERT INTO Lancamentos(Titulo, Sinopse, IdCategoria, TempoDuracao, IdTipoFilmeSerie, DataLancamento)
VALUES ('Homem-Aranha: Longe de Casa', 'Peter Parker est� em uma viagem de duas semanas pela Europa, ao lado de seus amigos de col�gio', 3, '129', 1, '04/06/2019');
       
INSERT INTO Categorias (Categoria)
VALUES ('Terror');

UPDATE Categorias
SET	Categoria = 'A��o' 
WHERE IdCategoria = 1;

UPDATE Categorias
SET	Categoria = 'Com�dia' 
WHERE IdCategoria = 7;

INSERT INTO Categorias (Categoria)
VALUES ('Document�rio'), ('Fic��o Cient�fica');



	