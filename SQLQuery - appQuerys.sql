use CATALOGO_DB

select * from ARTICULOS

select * from MARCAS

select * from CATEGORIAS

select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS Marca, A.IdCategoria, C.Descripcion AS Categoria, A.ImagenUrl as Foto, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C
where A.IdMarca = M.Id AND A.IdCategoria = C.Id

select Id, Descripcion from MARCAS

select Id, Descripcion from CATEGORIAS



update ARTICULOS set Codigo = 'a', Nombre = 'a', Descripcion = 'a', IdMarca = 1, IdCategoria = 2, ImagenUrl='a', Precio = 4 where id = 19