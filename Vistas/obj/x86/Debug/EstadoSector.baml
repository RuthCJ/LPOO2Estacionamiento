   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.EstadoSector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >local,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � Title$  EstadoSector��5   	   $	��300��6   $	��300��6+   $	��300��67   $	��300��6G    � WindowStartupLocation$ CenterScreen=�5   
    � Icon$( "/Vistas;component/Images/Logo1.PNG��6/      MyWindowDefault#��[  5   	    � 	Resources 5	        
TiemposXml � Source � XPath#   ClasesBase.ConversorDeEstados  ConversorDeEstados��%�   &	       &	 l     � 5   
   $= 7pack://application:,,,/ClasesBase;component/Tiempos.xml?�6-   $ /Tiempos/Tiempo��6n     5   
   6@   5      .��5      � ���	#FF003053.+�5   
   �� -   5         ��Name$ comboBox��5      $
��Left=�6%   $	��Top=�6@   $��20q�6X   $	��200��6d    �� SelectedIndex$ 0��5      ���	#FF7ED8CE���	#FF7ED8CE��5      ��  �� Source# [ 5   8   �� 5   
   -   5        	 ��Name$	 
rectangulo��5      $	��100��6(   $	��100��64   $��Center=�6A   $��Center=�6^   ��5      �� 5      
 �� Path$
 SelectedValue�6    �� ElementName$ comboBox��6/    �� 	Converter# [ 6F   5      5      5      