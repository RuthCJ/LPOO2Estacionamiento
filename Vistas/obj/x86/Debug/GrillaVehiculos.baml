   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.GrillaVehiculos   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	   -   5          � Title$  Lista deVehículos��5   	   $	��408��6#   $	��463��60    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$( "/Vistas;component/Images/Logo1.PNG��6.      MyWindowDefault#��[  5   	    � 	Resources 5	        list_vehiculo S� 
ObjectType&    ClasesBase.TrabajarTiposVehiculo S� 
MethodName��%Q   &	       S� 5
   
   "  5      $ TraerTiposVehiculo��5      5      5      .��5      � ���	#FF0F216B.+�5   
   �� -   5        $��	Vehiculos��5      $
��Auto��6$   $
��Auto��61   $��Center=�6}   $��10q�6�   $��
Constantia)�6�   $��18(�6�   ���	#FF124D93���	#FF7ED8CE$��Center=�6  $��Center=�63  ��6?   ��  �� Source# [ ��6�   Z� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value$	 Center=�6C   5      
 �� View
 5      �� 5        GridViewColumnHeaderStyle1! �� ColumnHeaderContainerStyle# [ 6   .P�5      ��  �� Width$
 Auto��6%   $��Código��62    �� DisplayMemberBinding 6B   ��  �� Path$ tv_TVCodigo��� 5      $
 Auto��6%   $��Descripción��62    6G   �� $ tv_Descripcion��� 5      $
 Auto��6%   $��Tarifa��62    6B   �� $ 	tv_Tarifa��� 5      $
 Auto��6%   $��Imagen��62    �� CellTemplate 5       �� 5!      .R�5"   "   �� $��50��6J   $��50��6U   ��6(   �� $ 	tv_Imagen�6U   5#      5%      5'      5)      5*      5+      