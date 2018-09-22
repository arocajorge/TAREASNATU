
create PROCEDURE [dbo].[spseg_corregir_menu]
( 
@IdUsuario varchar(20)
)
AS



insert into Seg_Menu_x_usuario
select  @IdUsuario, menu.IdMenuPadre, 0,0,0
from seg_Menu as menu
join Seg_Menu_x_usuario as me
on me.IdMenu = menu.IdMenu
where 
 me.IdUsuario = @IdUsuario
and menu.IdMenuPadre != 0
and not exists(
select * from Seg_Menu_x_usuario as f
where 
 f.IdMenu = menu.IdMenuPadre
and f.IdUsuario = @IdUsuario
)
group by menu.IdMenuPadre

insert into Seg_Menu_x_usuario
select  @IdUsuario, menu.IdMenuPadre, 0,0,0
from seg_Menu as menu
join Seg_Menu_x_usuario as me
on me.IdMenu = menu.IdMenu
where 
 me.IdUsuario = @IdUsuario
and menu.IdMenuPadre != 0
and not exists(
select * from Seg_Menu_x_usuario as f
where 
 f.IdMenu = menu.IdMenuPadre
and f.IdUsuario = @IdUsuario
)
group by menu.IdMenuPadre