   M S B A M L   `   `   `  ����B  >Scene3D, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Scene3DScene3D  5   	       Scene3D.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Scene3D     5   	     � Title$  Scene3D��5   	   $��432.394��6   $��334.579��6*    � Icon$ oszimtlogo_Y9z_icon.ico��6:    � 
ResizeMode$ NoResize=�6Y   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��164 �6   �� 5      $
��157* �6   �� 5      $��6* �6    � RowDefinitions 5   
   �� 5      $	��19* �6   �� 5      $	��81* �6   �� 5      $	��67* �6   �� 5      $
��133* �6   �� 5      $
��101* �6   .+�5   
   o� -   5         o�Name$
 menu��5      $��19��6   $	��Top=�6)   $��0,0,-1,0q�6A   $��3��6S   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Open��5      6*   5      m� 5      $��_Object��6   .@�5      m� $��Basic Objects��6   .@�5      m� -   5        $��CubeObjectMenuItem��5      $
��Cube��69   6G   m� 5      -   5        $��SphereObjectMenuItem��5      $��Sphere��6;   6K   m� 5      -   5        $��CylinderObjectMenuItem��5      $��Cylinder��6=   6O   m� 5      -   5        $��ConeObjectMenuItem��5      $
��Cone��69   6G   m� 5       -   5        $��GearObjectMenuItem��5       $
��Gear��69   6G   5!      m� 5"      -   5        $��ColorPickerMenuItem��5"      $��Color��66   6E   5#      m� 5$      $
��Help��6   .@�5%      m� -	   5        $��AboutDialog��5%      $��About��6.   6=   5&      5'      �� 5(   
   
���   �$��1q�6%   $��10,2,0,0q�69   $��1��6K   $��2��6X   $��3��6l      Scene3D.MyCanvas  5)   
   -
   5          Name$ myCanvas��5)         Scene3D.MyCanvas   
MouseWheel$ OnZoom��6V   $��	10,2,16,0q�6+   $	��Top=�6>   $��3��6j   $��2��6w   $��0��6�   �� 5*   
   -   5         ��Name$ XAxisRotation��5*      $��59,27,0,-22q�6)   $��4��6i   $��2��6v   	 � Maximum$		 360Q�6�   �� 5+   
   -   5        $ YAxisRotation��5+      $��59,51,0,-22q�6)   $��4��6h   $��2��6u   $		 360Q�6�   �� 5,   
   -   5        $ ZAxisRotation��5,      $��59,73,0,-22q�6)   $��4��6h   $��2��6u   $		 360Q�6�   �� 5-   
   -   5        
 ��Name$
 label��5-      $��X Axis��6   $
��Left=�60   $��	10,23,0,0q�6K   $	��Top=�6^   $��24��6v   $��4��6�   $��42��6�   �� 5.   
   -   5        $
 
label_Copy��5.      $��Y Axis��6$   $
��Left=�65   $��	10,43,0,0q�6P   $	��Top=�6c   $��26��6{   $��4��6�   $��41��6�   �� 5/   
   -   5        $
 label_Copy1��5/      $��Z Axis��6%   $
��Left=�66   $��	10,67,0,0q�6Q   $	��Top=�6d   $��24��6|   $��4��6�   $��41��6�   50      51      