   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC"   SISJORSAC.FrmClienteRegistro   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Registrar Clientes��5   	    � WindowStartupLocation$ CenterScreen=�6%   $	��546��5   	   $	��680��6    � 
ResizeMode$ NoResize=�6"   .��5
      � -   5         �Name$ 
Clientesss��5
      $��0,0,2,0q�6   .+�5   
   �� $
��Left=�6   $��
17,0,0,383q�6+   $	��134��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Nombre:��6   $
��Left=�6"   $��
20,138,0,0q�6=   $	��Top=�6Q   $
��Bold"�6i   �� 5   
   $��Apellido Paterno:��6   $
��Left=�6,   $��
20,171,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   �� 5   
   $��Apellido Materno:��6   $
��Left=�6,   $��
20,203,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   �� 5   
   -   5         ��Name$ lblTipoDocumento��5      $
��DNI:��6*   $
��Left=�69   $��
20,237,0,0q�6T   $	��Top=�6h   $
��Bold"�6�   �� 5   
   $��Razón Social:��6   $
��Left=�6(   $��
20,272,0,0q�6C   $	��Top=�6W   $
��Bold"�6o   �� 5   
   $��Dirección:��6   $
��Left=�6%   $��
20,306,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   �� 5   
   $��Departamento:��6   $
��Left=�6(   $��397,135,0,0q�6C   $	��Top=�6X   $
��Bold"�6p   �� 5   
   $��
Provincia:��6   $
��Left=�6%   $��421,166,0,0q�6@   $	��Top=�6U   $
��Bold"�6m   �� 5   
   $��	Distrito:��6   $
��Left=�6$   $��431,197,0,0q�6?   $	��Top=�6T   $
��Bold"�6l   �� 5   
   $��Telf. Fijo Casa:��6   $
��Left=�6+   $��
20,337,0,0q�6F   $	��Top=�6Z   $
��Bold"�6r   �� 5   
   $��Telf. Fijo Oficina:��6   $
��Left=�6.   $��
17,368,0,0q�6I   $	��Top=�6]   $
��Bold"�6u   �� 5   
   $��Celular:��6   $
��Left=�6#   $��
20,399,0,0q�6>   $	��Top=�6R   $
��Bold"�6j   �� 5   
   $��Email:��6   $
��Left=�6!   $��
20,433,0,0q�6<   $	��Top=�6P   $
��Bold"�6h   �� 5   
   $��Observaciones:��6   $
��Left=�6)   $��
20,461,0,0q�6D   $	��Top=�6X   $
��Bold"�6p   �� 5   
   $��Tipo de Cliente��6   $
��Left=�6,   $��
283,62,0,0q�6G   $	��Top=�6[   $	��218��6s   $��60��6   ���	#CC08236C$��14(�6�   $
��Bold"�6�   	� 5   
   -   5         	�Name$ 	rdNATUTAL��5      $��NATURAL��6)   $
��Left=�6;   $��
292,97,0,0q�6V   $	��Top=�6j   $
��Bold"�6�   	� 5   
   -   5        $ 
rbJURIDICA��5      $��JURIDICA��6*   $
��Left=�6=   $��
379,97,0,0q�6X   $	��Top=�6l    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��Bold"�6�   z�5      V� 5      .~�5      �� �� 5        �� AngleX$ 2.862Q�6$   �� 5!      T� 5"       T� X$ -0.45Q�6)   5#      5%      �� 5&   
   -   5        	 ��Name$	 	txtNombre��5&      $
��Left=�6%   $��23��6@   $��128,139,0,0q�6L   
 �� TextWrapping$

 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��219��6�   $
��Bold"�6�   �� 5'   
   -   5        $	 txtAPPaterno��5'      $
��Left=�6(   $��23��6C   $��128,172,0,0q�6O   $

 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��219��6�   $
��Bold"�6�   �� 5(   
   -   5        $	 txtAPMaterno��5(      $
��Left=�6(   $��23��6C   $��128,202,0,0q�6O   $

 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��219��6�   $
��Bold"�6�   �� 5)   
   -   5        $	 txtDocumento��5)      $
��Left=�6(   $��23��6C   $��128,238,0,0q�6O   $

 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��104��6�   $
��Bold"�6�   �� 5*   
   -	   5        $	 txtRazonSocial��5*      $
��Left=�6*   $��23��6E   $��128,272,0,0q�6Q   $

 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��395��6�   $
��Bold"�6�   �� 5+   
   -
   5        $	 txtDireccion��5+      $
��Left=�6(   $��23��6C   $��128,307,0,0q�6O   $

 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��395��6�   $ 	0.6,7.115&�6�   $
��Bold"�6�   �� 5,   
   -   5        $	 txtTelfFijoCasa��5,      $
��Left=�6+   $��23��6F   $��128,337,0,0q�6R   $

 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��115��6�   $
��Bold"�6�   �� 5-   
   -   5        $	 txtTelfFijoOficina��5-      $
��Left=�6.   $��23��6I   $��128,368,0,0q�6U   $

 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��115��6�   $
��Bold"�6�   �� 5.   
   -   5        $	 
txtCelular��5.      $
��Left=�6&   $��23��6A   $��128,399,0,0q�6M   $

 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��115��6�   $
��Bold"�6�   �� 5/   
   -   5        $	 txtEmail��5/      $
��Left=�6$   $��23��6?   $��128,431,0,0q�6K   $

 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��248��6�   $
��Bold"�6�   �� 50   
   -   5        $	 txtObservaciones��50      $
��Left=�6,   $��43��6G   $��128,462,0,0q�6S   $

 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��248��6�   $
��Bold"�6�   �� 51   
   -   5         ��Name$ cboDepartamento��51      $
��Left=�6,   $��491,135,0,0q�6G   $	��Top=�6\   $	��174��6t   $
��Bold"�6�   �� 52   
   -   5        $ cboProvincia��52      $
��Left=�6)   $��491,166,0,0q�6D   $	��Top=�6Y   $	��174��6q   $
��Bold"�6�   �� 53   
   -   5        $ cboDistrito��53      $
��Left=�6(   $��491,197,0,0q�6C   $	��Top=�6X   $	��174��6p   $
��Bold"�6|   �� 54   
   -   5         ��Name$ btnCrearCliente��54      $��Crear Cliente��6*   $
��Left=�6B   $��524,429,0,0q�6]   $	��Top=�6r   $	��137��6�   $��30��6�   ���	#FF2C6BAA$
��Bold"�6�   ���	#FFFBFBFB6�   �� 55   
   -   5        $ btnLimpiarTodo��55      $��Limpiar Todo��6)   $
��Left=�6@   $��524,475,0,0q�6[   $	��Top=�6p   $	��137��6�   $��30��6�   ���	#FFD4210F$
��Bold"�6�   
�������6�   56      57      