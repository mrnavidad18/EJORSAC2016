   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmUsuarioDatos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Actualiza Tu Información��5   	   $	��269��6*   $	��690��67    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � -   5        $��UsuarioContraseña��5
      $��	0,0,-8,-1q�6$    � ColumnDefinitions 5   
   �� 5      $
��118* �6   �� 5      .+�5   
   �� $��	Username:��6   $
��Left=�6$   $��
123,63,0,0q�6?   $	��Top=�6S   $��26��6k   $��74��6w   $
��Bold"�6�   �� 5   
   $��Clave:��6   $
��Left=�6!   $��
422,61,0,0q�6<   $	��Top=�6P   $��26��6h   $��60��6t   $
��Bold"�6   �� 5   
   $��Nombre:��6   $
��Left=�6"   $��
123,22,0,0q�6=   $	��Top=�6Q   $��26��6i   $��83��6u   $
��Bold"�6�   �� 5   
   $��
Apellidos:��6   $
��Left=�6%   $��
407,22,0,0q�6@   $	��Top=�6T   $��26��6l   $��69��6x   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtUsername��5      $
��Left=�6'   $��17��6B   $��
206,63,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��185��6�   $
��Bold"�6�   G� 5   
   -   5         G�Name$ txtClave��5      $
��Left=�6(   $��26��6C   $��
482,61,0,0q�6O   $	��Top=�6d   $	��187��6|   �� 5   
   -   5        $ txtApellidos��5      $
��Left=�6(   $��26��6C   $��482,22,-83,0q�6O   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��185��6�   $��2��6�   �� 5   
   -   5        $ 	txtNombre��5      $
��Left=�6%   $��26��6@   $��
206,22,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��185��6�    J� RenderTransformOrigin$ 0.658,-4.192&�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ btnGuardarCambios��5      $��Guardar Cambios��6,   $
��Left=�6F   $��503,200,0,0q�6a   $	��Top=�6v   $	��166��6�   $��29��6�   $ -0.295,2.241&�6�   ���	#FF3F8FBD
�������$
��Bold"�6  �� 5   
   -   5        	 ��Name$	 lblNuevaContra��5      $��Nueva Contraseña:��6(   $
��Left=�6D   $��121,105,0,0q�6_   $	��Top=�6t   $��26��6�   $	��115��6�   $
��Bold"�6�   G� 5   
   -   5        $ txtnuevaContra��5      $
��Left=�6.   $��26��6I   $��257,105,0,0q�6U   $	��Top=�6k   $	��185��6�   $
��Bold"�6�   �� 5   
   -	   5        $	 lblConfirmarContra��5      $��Confirme Contraseña:��6,   $
��Left=�6K   $��121,147,0,0q�6f   $	��Top=�6{   $��26��6�   $	��127��6�   $
��Bold"�6�   G� 5   
   -
   5        $  txtConfirmacionNuevaContra��5      $
��Left=�6:   $��26��6U   $��257,145,0,0q�6a   $	��Top=�6w   $	��185��6�   $
��Bold"�6�   �� 5   
   -   5        
 ��Name$
 chkCambiarContraseña��5      $��Cambiar Contraseña ��61   $
��Left=�6O   $��477,108,0,0q�6j   $	��Top=�6   $
��Bold"�6�   $	��152��6�   6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��30��6T   $��469,101,0,0q�6`   $	��Top=�6u   $	��161��6�   �� 5   
   $
��Left=�6   $��	-4,0,0,67q�6+   $	��125��6>   $	��145��6J   $��Bottom=�6W   $
��Fill=�6r   $��IMG/logo_rep.PNG��6�   5       5!      