   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmBoleta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   -   5          � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ NoResize=�6<    � Title$ 	FrmBoleta��5	   	   $��661.425��6   $��921.276��6-   .��5
      � .+�5   
   �� $
��Left=�6   $	��136��6+   $��	21,18,0,0q�68   $	��Top=�6K   $	��163��6c   $��IMG/logo_rep.PNG��6o   �� 5   
   $��Tipo Compro.:��6   $
��Left=�6(   $��
215,31,0,0q�6C   $	��Top=�6W   �� 5   
   $
��Left=�6   $��23��6-   $��
316,33,0,0q�69    �� TextWrapping$
 Wrap=�6M   $��BOLETA DE VENTA��6a   $	��Top=�6x   $	��112��6�   {�.  6�   �� 5   
   $��Nro. Boleta:��6   $
��Left=�6'   $��
445,33,0,0q�6B   $	��Top=�6V    J� RenderTransformOrigin$ 0.903,0.444&�6n   �� 5   
   -   5         ��Name$ txtNroBoleta��5      $
��Left=�6(   $��23��6C   $��
530,33,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $��70��6�    �� 	MaxLength$ 6��6�   {�.  6�   �� 5   
   $��Fech. Emisión:��6   $
��Left=�6)   $��
617,31,0,0q�6D   $	��Top=�6X   $ -0.352,-0.381&�6p   �� 5   
   -   5        $ txtFechaEmision��5      $
��Left=�6+   $��23��6F   $��
700,31,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $��97��6�   �� 5   
   $��Cliente:��6   $
��Left=�6#   $��
215,96,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ 
cboCliente��5      $
��Left=�6'   $��
293,97,0,0q�6B   $	��Top=�6V   $	��307��6n   $ 	0.125,0.5&�6z    �� 
IsEditable . {�.  6�   �� 5   
   $��RUC/DNI:��6   $
��Left=�6#   $��
621,97,0,0q�6>   $	��Top=�6R   $ 8.592,0.692&�6j   �� 5   
   $��
Direccion:��6   $
��Left=�6%   $��212,129,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ txtDireccion��5      $
��Left=�6(   $��23��6C   $��293,131,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��307��6�   {�.  6�   �� 5   
   -   5        $ 	txtDniRuc��5      $
��Left=�6%   $��23��6@   $��
700,98,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $��97��6�   {�.  6�   �� 5   
   -   5        $ cboModalidad��5      $
��Left=�6)   $��503,163,0,0q�6D   $	��Top=�6Y   $��97��6q   .@�5      �� $��VENTA��6   �� 5      $��ALQUILER��6   5      �� 5   
   $��
Modalidad:��6   $
��Left=�6%   $��418,163,0,0q�6@   $	��Top=�6U   �� 5   
   -   5        $ 	cboMoneda��5      $
��Left=�6&   $��700,162,0,0q�6A   $	��Top=�6V   $��97��6n   .@�5      �� $��S/. - SOLES��6   �� 5      $��US$ - DOLARES��6   5       �� 5!   
   $��Moneda:��6   $
��Left=�6"   $��621,162,0,0q�6=   $	��Top=�6R   �� 5"   
   -	   5        	 ��Name$	 btnAgregarDetalle��5"      $��Agregar Detalle��6,   $
��Left=�6F   $��661,239,0,0q�6a   $	��Top=�6v   $	��136��6�   ���	#FF3D97F1
�������$
��Bold"�6�   �� 5#   
   -
   5        $	 btnEliminar��5#      $��Eliminar��6&   $
��Left=�69   $��572,239,0,0q�6T   $	��Top=�6i   $��81��6�   ���	#FFEE0B00
�������$ 
-0.4,0.586&�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5$   
   -   5        
  Name$
 
dgvListado��5$      $��Right=�6(   $	��Top=�6F   $��0,278,106,0q�6_   $	��782��6t   $	��257��6�   ���	#FFB8B6B6   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�5(         CanUserDeleteRows .    CanUserResizeRows .     CanUserSortColumns .     HeadersVisibility$ Column=�5,         GridLinesVisibility$
 None=�5-         SelectionUnit$ FullRow=�5.      ���	#FFA8A8A8$��1q�6E      Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      -   5        ITEM��,  &System.Windows.Controls.DataGridColumn   Header$
 ITEM��50   3      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$
 ITEM� �� StringFormat$
 0{0}��6s     51      -   5        CANTIDAD��$ CANTIDAD��51   7    .   6I   �� $ CANTIDAD�   EditingElementStyle 52      �� 53       �� 
TargetType" ��6    .�54      -   5        55      57        58      -   5        DESCRIPCION��$' !DESCRIPCION: CONCEPTO DE SERVICIO��58   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6�    6e   �� $ SERVICIO.DESCRIPCION�6�     59      -   5        
PRECIO��$ PRECIO UNITARIO��59   5    .  6N   �� $ PRECIO�6n     5:      -   5        IMPORTE��$ IMPORTE��5:   6    . $ * 6z    6G   �� $ IMPORTE�6z   5=      �� 5>   
   $#��DETALLE DE LA BOLETA DE VENTA��6   $
��Left=�68   $	��Top=�6T   $ -2.758,5.192&�6l   ���	#FF3DA4F9$
��Bold"�6�   $��
21,247,0,0q�6�   �� 5?   
   -   5         ��Name$ chkCambiarNroBol��5?      $��Cambiar Nro. Bol.��6-   $
��Left=�6I   $��
503,10,0,0q�6d   $	��Top=�6x   6�   �� 5@   
   -   5        $ txtTotal��5@      $
��Left=�6$   $��23��6?   $��707,544,0,61q�6K   $
 Wrap=�6a   $��87��6u   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5A   
   $��Total:��6   $
��Left=�6!   $��666,543,0,0q�6<   $	��Top=�6Q   $ 1.553,0.423&�6i   �� 5B   
   -   5        $	 btnGenerarFactura��5B      $��Generar Boleta��6,   $
��Left=�6E   $��588,582,0,0q�6`   $	��Top=�6u   $	��137��6�   ���	#FF42A5F7
�������$
��Bold"�6�   $��35��6�   6�   �� 5C   
   -   5        $	 txtCancelar��5C      $��Salir��6&   $
��Left=�66   $��739,582,0,0q�6Q   $	��Top=�6f   $��64��6~   $��35��6�   ���	#FFE24030���	#FFAEAEAE
�������$
��Bold"�6�   6�   �� 5D   
   -   5        $ chkObservacion��5D      $��Ingresar observaciones��6+   $
��Left=�6L   $��
44,544,0,0q�6g   $	��Top=�6{   6�   �� 5E   
   -   5        $ txtObservacion��5E      $
��Left=�6*   $��58��6E   $��
44,563,0,0q�6Q   $
 Wrap=�6e   $	��Top=�6y   $	��306��6�   {�.  6�   �� 5F   
   $��Nro. Guía:��6   $
��Left=�6%   $��621,128,0,0q�6@   $	��Top=�6U   �� 5G   
   -   5        $ 
txtNroGuia��5G      $
��Left=�6&   $��23��6A   $��701,129,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $��95��6�   {�.  6�   	� 5H   
   -   5         	�Name$ 	rbNATURAL��5H      $��NATURAL��6)   $
��Left=�6;   $��
297,69,0,0q�6V   $	��Top=�6j   6�   	� 5I   
   -   5        $ 
rbJURIDICA��5I      $��JURIDICA��6*   $
��Left=�6=   $��
409,69,0,0q�6X   $	��Top=�6l   6�   �� 5J   
   $��Tipo Cliente:��6   $
��Left=�6(   $��
212,65,0,0q�6C   $	��Top=�6W   $ 0.531,-0.346&�6o   �� 5K   
   $��	Servicio:��6   $
��Left=�6$   $��156,198,0,0q�6?   $	��Top=�6T   �� 5L   
   -   5        $ cboServicio��5L      $
��Left=�6(   $��215,198,0,0q�6C   $	��Top=�6X   $	��317��6p    . 6�   �� 5M   
   $��	Cantidad:��6   $
��Left=�6$   $��540,198,0,0q�6?   $	��Top=�6T   �� 5N   
   -   5        $ txtCantidad��5N      $
��Left=�6'   $��23��6B   $��608,198,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��45��6�   $ 5��6�   6�   �� 5O   
   $��Precio:��6   $
��Left=�6"   $��676,198,0,0q�6=   $	��Top=�6R   �� 5P   
   -   5        $ 	txtPrecio��5P      $
��Left=�6%   $��23��6@   $��726,198,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��70��6�   ���	#FFB6B6B66�   �� 5Q   
   -   5        $	 btnCambiarFactura��5Q      $��Factura��6,   $
��Left=�6>   $��826,364,0,0q�6Y   $	��Top=�6n   $��79��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   �� 5R   
   $��
Cambiar a:��6   $
��Left=�6%   $��829,336,0,0q�6@   $	��Top=�6U   �� 5S   
   -   5        $	 btnCambiarContrato��5S      $��Contrato��6-   $
��Left=�6@   $��824,398,0,0q�6[   $	��Top=�6p   $��81��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   �� 5T   
   -    5        $	 btnCambiarGuia��5T      $��Guía��6)   $
��Left=�68   $��824,431,0,0q�6S   $	��Top=�6h   $��81��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   5V      5W      