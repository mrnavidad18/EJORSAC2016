   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC!   SISJORSAC.FrmChoferRegistro   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Registro de Choferes��5   	   $��309.1��6&   $	��637��65    � WindowStartupLocation$ CenterScreen=�5   	   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �	#FF633333 � 
ResizeMode$ NoResize=�6K   .��5
      � -   5        $��
GridChofer��5
      $��0,0,-8,0q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Nombres:��6   $
��Left=�6#   $��
133,47,0,0q�6>   $	��Top=�6R   $��26��6j   $��74��6v   �� 5   
   $��
Apellidos:��6   $
��Left=�6%   $��
133,81,0,0q�6@   $	��Top=�6T   $��26��6l   $��60��6x   �� 5   
   $��Nro Brevete:��6   $
��Left=�6'   $��133,112,0,0q�6B   $	��Top=�6W   $��26��6o   $��83��6{   �� 5   
   -   5         ��Name$ 
txtNombres��5      $
��Left=�6&   $��26��6A   $��
275,47,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��294��6�   �� 5   
   -   5        $ txtApellidos��5      $
��Left=�6(   $��26��6C   $��
276,81,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��293��6�   �� 5   
   -   5        $ txtNroBrevete��5      $
��Left=�6)   $��26��6D   $��276,114,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��134��6�   �� 5   
   -   5         ��Name$ btnAgregarChofer��5      $��Agregar Chofer��6+   $
��Left=�6D   $��133,229,0,0q�6_   $	��Top=�6t   $	��145��6�   $��29��6�   ���	#FF76A5DE$
��Bold"�6�   ���	#FFF3F3F36�   �� 5   
   -   5        $ btnLimpiarTodo��5      $��Limpiar Todo��6)   $
��Left=�6@   $��304,229,0,0q�6[   $	��Top=�6p   $	��140��6�   ���	#FFD43434
�������$
��Bold"�6�   6�   �� 5   
   $
��Left=�6   $��	0,0,0,130q�6+   $	��125��6>   $	��121��6J   $��Bottom=�6W   $
��Fill=�6r   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Nº de Certificado:��6   $
��Left=�6-   $��133,148,0,0q�6H   $	��Top=�6]   $��26��6u   $	��112��6�   �� 5   
   $��Marca/Placa Vehículo:��6   $
��Left=�60   $��133,178,0,0q�6K   $	��Top=�6`   $��26��6x   $	��128��6�   �� 5   
   -   5        $ txtNroCertificado��5      $
��Left=�6-   $��26��6H   $��276,148,0,0q�6T   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��134��6�   �� 5   
   -   5        $ txtVehiculoMARCA��5      $
��Left=�6,   $��26��6G   $��275,178,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��337��6�   5      5      