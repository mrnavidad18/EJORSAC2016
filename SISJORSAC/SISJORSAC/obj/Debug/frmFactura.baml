   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.frmFactura   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  Registro - Factura��5   	   $��641.425��6$   $��980.276��65    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�5
   	   (   "MahApps.Metro.Controls.MetroWindow   ShowMaxRestoreButton .  .��5      � .+�5   
   �� $
��Left=�6   $	��148��6+   $��32,8,0,0q�68   $	��Top=�6J   $	��162��6b   $��IMG/logo_rep.PNG��6n   �� 5   
   $��Tipo Compro.:��6   $
��Left=�6(   $��	235,0,0,0q�6C   $	��Top=�6V   �� 5   
   $
��Left=�6   $��23��6-   $��	320,8,0,0q�69    �� TextWrapping$
 Wrap=�6L   $��FACTURA��6`   $	��Top=�6o   $��65��6�   {�.  6�   �� 5   
   $��Nro. Factura:��6   $
��Left=�6(   $��	396,7,0,0q�6C   $	��Top=�6V    J� RenderTransformOrigin$ 0.903,0.444&�6n   �� 5   
   -   5         ��Name$ txtNroFactura��5      $
��Left=�6)   $��23��6D   $��	477,8,0,0q�6P   $
 Wrap=�6c   $	��Top=�6w   $	��102��6�   {�.  6�   �� 5   
   $��Fech. Emisión:��6   $
��Left=�6)   $��	718,8,0,0q�6D   $	��Top=�6W   $ -0.352,-0.381&�6o   �� 5   
   -   5        $ txtFechaEmision��5      $
��Left=�6+   $��23��6F   $��	807,8,0,0q�6R   $
 Wrap=�6e   $	��Top=�6y   $��83��6�   �� 5   
   $��Razón Social:��6   $
��Left=�6(   $��
230,39,0,0q�6C   $	��Top=�6W   �� 5   
   -   5         ��Name$ cboRazonsocial��5      $
��Left=�6+   $��
318,39,0,0q�6F   $	��Top=�6Z   $	��389��6r   6~   �� 5   
   $��	Nro. RUC:��6   $
��Left=�6$   $��
720,39,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ txtRuc��5      $
��Left=�6"   $��23��6=   $��
807,39,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $��83��6�   {�.  6�   �� 5   
   -   5        $ txtDireccion��5      $
��Left=�6(   $��23��6C   $��
318,73,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��389��6�   {�.  6�   �� 5   
   $��Dirección:��6   $
��Left=�6%   $��
230,72,0,0q�6@   $	��Top=�6T   �� 5   
   $��Nro. Guía:��6   $
��Left=�6%   $��
723,73,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ 
txtNroGuia��5      $
��Left=�6&   $��23��6A   $��
807,73,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $��83��6�   {�.  6�   �� 5   
   $��
Modalidad:��6   $
��Left=�6%   $��360,108,0,0q�6@   $	��Top=�6U   �� 5   
   $��Moneda:��6   $
��Left=�6"   $��726,105,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $ 	cboMoneda��5      $
��Left=�6&   $��828,104,0,0q�6A   $	��Top=�6V   $��62��6n   .@�5      �� $	��S/.��6   �� 5       $��$��6   5!      �� 5"   
   -	   5         ��Name$ chkIgv��5"      $��Sin IGV��6#   $
��Left=�65   $��820,197,0,0q�6P   $	��Top=�6e   $ 
0.21,1.778&�6}   6�   &   System.Windows.Controls.DataGrid  5#   
   -
   5        	  Name$	 
dgvListado��5#      $��Right=�6(   $	��Top=�6F   $��0,245,104,0q�6_   $	��835��6t   $	��257��6�   ���	#FFB8B6B6
   AutoGenerateColumns
 .     CanUserAddRows .     SelectionMode$ Single=�5'         CanUserDeleteRows .    CanUserResizeRows .     CanUserSortColumns .     HeadersVisibility$ Column=�5+         GridLinesVisibility$
 None=�5,         SelectionUnit$ FullRow=�5-      ���	#FFA8A8A8$��1q�64      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      -   5        ITEM��,  &System.Windows.Controls.DataGridColumn   Header$
 ITEM��5/   3      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *ITEM+ �� StringFormat$
 0{0}��6o     50      -   5        CANTIDAD��$ CANTIDAD��50   7    .   6I   �� *
CANTIDAD+   EditingElementStyle 51      �� 52       �� 
TargetType" ��6    .�53      -   5        54      56        57      -   5        DESCRIPCION��$ CONCEPTO DE SERVICIO��57   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 6�    6X   �� *SERVICIO.DESCRIPCION+6�     58      -   5        DIAS��$
 DIAS��58   3    .   6A   �� *DIAS+ 59      �� 5:      " ��6    .�5;      -   5        5<      5>        5?      -   5        
PRECIO��$ PRECIO UNITARIO��5?   5    .  6N   �� *PRECIO+6i     5@      -   5        IMPORTE��$ IMPORTE��5@   6    . $ * 6u    6G   �� *	IMPORTE+6u   5C      �� 5D   
   -   5        $ chkCambiarNroFact��5D      $��Cambiar Nro. Fact.��6.   $
��Left=�6K   $��
585,14,0,0q�6f   $	��Top=�6z   6�   �� 5E   
   -   5        $ cboModalidad��5E      $
��Left=�6)   $��432,108,0,0q�6D   $	��Top=�6Y   $	��120��6q   .@�5F      �� $��VENTA��6   �� 5G      $��ALQUILER��6   5H      �� 5I   
   $��	Servicio:��6   $
��Left=�6$   $��230,143,0,0q�6?   $	��Top=�6T   �� 5J   
   -   5        $ cboServicio��5J      $
��Left=�6(   $��315,143,0,0q�6C   $	��Top=�6X   $	��317��6p    �� 
IsEditable . 6�   �� 5K   
   $��	Cantidad:��6   $
��Left=�6$   $��642,143,0,0q�6?   $	��Top=�6T   �� 5L   
   -   5        $ txtCantidad��5L      $
��Left=�6'   $��23��6B   $��709,143,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��45��6�   6�   �� 5M   
   -   5         ��Name$ 
btnAgregar��5M      $��Agregar Detalle��6%   $
��Left=�6?   $��665,191,0,0q�6Z   $	��Top=�6o   $	��137��6�   
����������	#FF42A9FF$
��Bold"�6�   �� 5N   
   $��Precio:��6   $
��Left=�6"   $��764,143,0,0q�6=   $	��Top=�6R   �� 5O   
   -   5        $ 	txtPrecio��5O      $
��Left=�6%   $��23��6@   $��820,143,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��70��6�   ���	#FFB6B6B66�   �� 5P   
   -   5        $ chkObservacion��5P      $��Ingresar observaciones��6+   $
��Left=�6L   $��
44,511,0,0q�6g   $	��Top=�6{   6�   �� 5Q   
   -   5        $ txtSubtotal��5Q      $
��Left=�6'   $��23��6B   $��778,508,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5R   
   -   5        $ txtIgv��5R      $
��Left=�6"   $��23��6=   $��778,536,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5S   
   -   5        $ txtTotal��5S      $
��Left=�6$   $��23��6?   $��778,564,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5T   
   $��
Sub Total:��6   $
��Left=�6%   $��712,507,0,0q�6@   $	��Top=�6U   $ 1.553,0.423&�6m   �� 5U   
   $
��IGV:��6   $
��Left=�6   $��735,535,0,0q�6:   $	��Top=�6O   $ 1.553,0.423&�6g   �� 5V   
   $��Total:��6   $
��Left=�6!   $��725,563,0,0q�6<   $	��Top=�6Q   $ 1.553,0.423&�6i   �� 5W   
   -   5        $ btnGenerarFactura��5W      $��Generar Factura��6,   $
��Left=�6F   $��379,554,0,0q�6a   $	��Top=�6v   $	��157��6�   ���	#FF42A5F7
�������$
��Bold"�6�   $��45��6�   �� 5X   
   -   5        $ txtObservacion��5X      $
��Left=�6*   $��58��6E   $��
44,531,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��306��6�   {�.  6�   �� 5Y   
   -   5        $ txtCancelar��5Y      $��Salir��6&   $
��Left=�66   $��557,554,0,0q�6Q   $	��Top=�6f   $	��103��6~   $��45��6�   ���	#FFE24030���	#FFAEAEAE
�������$
��Bold"�6�   6�   �� 5Z   
   -    5        $ btnEliminarDetalle��5Z      $��Eliminar��6-   $
��Left=�6@   $��585,191,0,0q�6[   $	��Top=�6p   $��75��6�   ���	#FFF10E0E���	#FFF9F3F3$
��Bold"�6�   �� 5[   
   -!   5        $ btnCambiarBoleta��5[      $��Boleta��6+   $
��Left=�6<   $��885,358,0,0q�6W   $	��Top=�6l   $��79��6�   ���	#FF13BD68$
��Bold"�6�   ���	#FFFDFDFD6�   �� 5\   
   -"   5        $ btnCambiarContrato��5\      $��Contrato��6-   $
��Left=�6@   $��885,392,0,0q�6[   $	��Top=�6p   $��79��6�   ���	#FF13BD68$
��Bold"�6�   ���	#FFFDFDFD6�   �� 5]   
   -#   5        $ btnCambiarGuia��5]      $��Guía��6)   $
��Left=�68   $��885,426,0,0q�6S   $	��Top=�6h   $��79��6�   ���	#FF13BD68$
��Bold"�6�   ���	#FFFDFDFD6�   �� 5^   
   $��
Cambiar a:��6   $
��Left=�6%   $��888,327,0,0q�6@   $	��Top=�6U   $
��Bold"�6m   �� 5_   
   -$   5        $ chkPendiente��5_      $��	Pendiente��6)   $
��Left=�6=   $��390,522,0,0q�6X   $	��Top=�6m   $��99��6�   $ 1.123,-0.889&�6�   �� 5`   
   -%   5        $ 
txtAcuenta��5`      $
��Left=�6&   $��23��6A   $��515,519,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��145��6�   6�   5b      5c      