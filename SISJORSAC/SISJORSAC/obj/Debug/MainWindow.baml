   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Ingreso��5   	   $��393.284��6   $��342.91��6*    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   �� -   5         ��Name$ 
txtUsuario��5      $
��Left=�6&   $��23��6A   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese su usuario��6M      ClearTextButton . $��
25,200,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��287��6�   6�   G� 5   
   -   5         G�Name$ txtClave��5      $
��Left=�6(   $ Ingrese su contraseña��6C    . $��
25,243,0,0q�6�   $	��Top=�6�   $	��287��6�   6�   �� 5   
   -   5         ��Name$ btnIngresar��5      $��Ingresar��6&   $
��Left=�69   $��
25,311,0,0q�6T   $	��Top=�6h   $	��287��6�   ���	#FF0A0A0A
�������6�   �� 5   
   $
��Left=�6   $��
88,0,0,186q�6+   $	��158��6?   $	��148��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   -   5        	 ��Name$	 lblUsuarioError��5      $��Falta llenar este campo��6)   $
��Left=�6K   $��
25,218,0,0q�6f   $	��Top=�6z   $	��114��6�   $��9(�6�   ���	#FFF10000
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.458Q�6&   T� 5      5      5      �� 5   
   -   5        $	 lblClaveError��5      $��Falta llenar este campo��6'   $
��Left=�6I   $��
25,265,0,0q�6d   $	��Top=�6x   $	��114��6�   $��9(�6�   ���	#FFF10000$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� 5!      $ -0.458Q�6&   T� 5"      5#      5%      5'      5)      