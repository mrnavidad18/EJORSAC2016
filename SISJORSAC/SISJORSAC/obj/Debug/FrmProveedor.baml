   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmProveedor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Registrar Proveedores��5   	    � WindowStartupLocation$ CenterScreen=�6'   $	��529��5   	   $	��711��6    � 
ResizeMode$ NoResize=�6"   .��5
      � -   5         �Name$ Proveedores��5
      $��0,0,2,0q�6    .+�5   
   �� $��Nombre:��6   $
��Left=�6"   $��
16,138,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   �� 5   
   $��Apellido Paterno:��6   $
��Left=�6,   $��359,137,0,0q�6G   $	��Top=�6\   $
��Bold"�6t   �� 5   
   $��Apellido Materno:��6   $
��Left=�6,   $��
16,169,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   �� 5   
   -   5         ��Name$ lblTipoDocumento��5      $
��DNI:��6*   $
��Left=�69   $��406,169,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   �� 5   
   $��Razón Social:��6   $
��Left=�6(   $��
16,207,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   �� 5   
   $��Dirección:��6   $
��Left=�6%   $��
15,247,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   �� 5   
   $��Departamento:��6   $
��Left=�6(   $��386,287,0,0q�6C   $	��Top=�6X   $
��Bold"�6p   �� 5   
   $��
Provincia:��6   $
��Left=�6%   $��413,330,0,0q�6@   $	��Top=�6U   $
��Bold"�6m   �� 5   
   $��	Distrito:��6   $
��Left=�6$   $��422,368,0,0q�6?   $	��Top=�6T   $
��Bold"�6l   �� 5   
   $��Telf. Fijo Casa:��6   $
��Left=�6+   $��
15,330,0,0q�6F   $	��Top=�6Z   $
��Bold"�6r   �� 5   
   $��Telf. Fijo Oficina:��6   $
��Left=�6.   $��408,207,0,0q�6I   $	��Top=�6^   $
��Bold"�6v   �� 5   
   $��Celular:��6   $
��Left=�6#   $��
15,361,0,0q�6>   $	��Top=�6R   $
��Bold"�6j   �� 5   
   $��Email:��6   $
��Left=�6!   $��
15,287,0,0q�6<   $	��Top=�6P   $
��Bold"�6h   �� 5   
   $��Observaciones:��6   $
��Left=�6)   $��
16,392,0,0q�6D   $	��Top=�6X   $
��Bold"�6p   �� 5   
   $��Tipo de Proveedor��6   $
��Left=�6.   $��
271,52,0,0q�6I   $	��Top=�6]   $	��272��6u   $��60��6�   ���	#CC215A896�   	� 5   
   -   5         	�Name$ 	rdNATUTAL��5      $��NATURAL��6)   $
��Left=�6;   $��
280,87,0,0q�6V   $	��Top=�6j   $
��Bold"�6�   	� 5   
   -   5        $ 
rbJURIDICA��5      $��JURIDICA��6*   $
��Left=�6=   $��
419,87,0,0q�6X   $	��Top=�6l   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 	txtNombre��5      $
��Left=�6%   $��23��6@   $��125,137,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��221��6�   $
��Bold"�6�   �� 5   
   -   5        $ txtAPPaterno��5      $
��Left=�6(   $��23��6C   $��471,136,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��219��6�   $
��Bold"�6�   �� 5   
   -   5        $ txtAPMaterno��5      $
��Left=�6(   $��23��6C   $��127,169,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��219��6�   $
��Bold"�6�   �� 5   
   -   5        $ txtDocumento��5      $
��Left=�6(   $��23��6C   $��471,169,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��104��6�   $
��Bold"�6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   �� 5    
   -	   5        $ txtRazonSocial��5       $
��Left=�6*   $��23��6E   $��125,206,0,0q�6Q   $
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��280��6�   $
��Bold"�6�   �� 5!   
   -
   5        $ txtDireccion��5!      $
��Left=�6(   $��23��6C   $��125,247,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��395��6�   $ 	0.6,7.115&�6�   $
��Bold"�6�   �� 5"   
   -   5        $ txtTelfFijoCasa��5"      $
��Left=�6+   $��23��6F   $��125,330,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��115��6�   $
��Bold"�6�   �� 5#   
   -   5        $ txtTelfFijoOficina��5#      $
��Left=�6.   $��23��6I   $��527,207,0,0q�6U   $
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��115��6�   $
��Bold"�6�   �� 5$   
   -   5        $ 
txtCelular��5$      $
��Left=�6&   $��23��6A   $��125,361,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��115��6�   $
��Bold"�6�   �� 5%   
   -   5        $ txtEmail��5%      $
��Left=�6$   $��23��6?   $��125,289,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��230��6�   $
��Bold"�6�   �� 5&   
   -   5        $ txtObservaciones��5&      $
��Left=�6,   $��43��6G   $��125,392,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��248��6�   $
��Bold"�6�   �� 5'   
   -   5        	 ��Name$	 cboDepartamento��5'      $
��Left=�6,   $��478,289,0,0q�6G   $	��Top=�6\   $	��213��6t   $
��Bold"�6�   �� 5(   
   -   5        $	 cboProvincia��5(      $
��Left=�6)   $��478,330,0,0q�6D   $	��Top=�6Y   $	��212��6q   $
��Bold"�6�   �� 5)   
   -   5        $	 cboDistrito��5)      $
��Left=�6(   $��478,366,0,0q�6C   $	��Top=�6X   $	��212��6p   $
��Bold"�6|   �� 5*   
   -   5        
 ��Name$
 btnCrearCliente��5*      $��Crear Proveedor��6*   $
��Left=�6D   $��227,445,0,0q�6_   $	��Top=�6t   $	��142��6�   ���	#FF3B6EDA
�������$
��Bold"�6�   �� 5+   
   -   5        $
 btnLimpiarTodo��5+      $��Limpiar Todo��6)   $
��Left=�6@   $��401,445,0,0q�6[   $	��Top=�6p   $	��119��6�   $
��Bold"�6�   
����������	#FFE40C0C6�   �� 5,   
   $
��Left=�6   $��	9,0,0,384q�6+   $	��125��6>   $	��121��6J   $��Bottom=�6W   $
��Fill=�6r   $��IMG/logo_rep.PNG��6�   5-      5.      