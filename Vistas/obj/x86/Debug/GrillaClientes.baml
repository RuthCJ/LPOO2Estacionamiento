   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.GrillaClientes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � Title$  Lista Clientes��5   	   $	��333��6    $	��456��6-    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$( "/Vistas;component/Images/Logo1.PNG��6.      MyWindowDefault#��[  5   	   ���	#FF003053 � 	Resources 5        list_cliente S� 
ObjectType    ClasesBase.TrabajarCliente S� 
MethodName��%L   &	       S� 5	   
   "  5      $ TraerClientes��5      5      5      .��5      � .+�5   
   �� -   5        $��Clientes��5      $
��Auto��6#   $
��Auto��61   $��Center=�6|   $��Center=�6�   $��
Constantia)�6�   $��18(�6�   ���	#FF124D93���	#FF7ED8CE$��Center=�6  ��6?   ��  �� Source# [ ��6�   Z� ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value$	 Center=�6C   5      
 �� View
 5      �� 5        GridViewColumnHeaderStyle1! �� ColumnHeaderContainerStyle# [ 6   .P�5      ��  �� Width$
 Auto��6%   $	��DNI��62    �� DisplayMemberBinding 6?   ��  �� Path$ cli_ClienteDNI��� 5      $
 Auto��6%   $��Apellido��62    6D   �� $ cli_Apellido��� 5      $
 Auto��6%   $��Nombre��62    6B   �� $ 
cli_Nombre��� 5      $
 Auto��6%   $��Telefono��62    6D   �� $ cli_Telefono�5       5"      5$      5%      