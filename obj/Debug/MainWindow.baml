   M S B A M L   `   `   `  ����P  LBasketballTeamManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BasketballTeamManagerBasketballTeamManager  5   	   I)clr-namespace:BasketballTeamManager.ViewsBasketballTeamManager.Views  5   	   &     BasketballTeamManager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BasketballTeamManager     5   	   ;vievs)clr-namespace:BasketballTeamManager.Views     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � WindowStyle$
 None=�6q    � 	Resources 5
         	CloseMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  OpenMenu��%
  &	        &	 �     �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMenu��6�   .\�5        $ 0��6'   $	 250Q�63     5      $ 0:0:0.5��6'   $ 0Q�69   5      5      �� 5   
   .��5      U� $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ GridMenu��6�   .\�5        $ 0��6'   $ 0Q�63     5      $ 0:0:0.5��6'   $	 250Q�69   5      5      5      	 � Triggers	 5      :� 5   
   
 :� RoutedEvent$
 ButtonBase.Click��6    :� 
SourceName$ ButtonClose��66   .[�5      �� -   5         ��Name$ CloseMenu_BeginStoryboard��5      #��[  6A   5      :� 5   
   $
 ButtonBase.Click��6   $ 
ButtonOpen��66   .[�5      �� #��[ 6   5      .��5       � .+�5!   
   � -   5         �Name$ GridBackground��5!      .+�5"      �� $��1��6   $��1��6-   ��6:   �� 5#      �� 5$   
   -   5         ��Name$ 
ButtonOpen��5$      $
��Left=�6%   $	��Top=�6@   $��25��6�   $��25��6�   $��0q�6�   ��6X   Z� ��6n   Z� .��5%      �� $��Assets/menu.png��6   5&      � 5'   
   -   5        $ GridMenu��5'      $	��250��6!   $
��Left=�6-   $��
-250 0 0 0q�6H   
������� J� RenderTransformOrigin$ 0.5,0.5&�6o   z�5(      V� 5)      .~�5*      �� �� 5+      �� 5,      T� 5-      5.      .+�50      �� .+�51      �� $	��120��6   $��Assets/basketball.png��6&   $��10 10 10 20q�6E   �� 52      ���#333333$��Champagne & Limousines)�60   $��18(�6X   ��6f   Z� .@�53      �� $��45��6#   $��0q�6/   .��54      �� -   5         �� Orientation$ 
Horizontal=�54   %   $��10 0 0 0q�6>   $	��230��6P   .+�55      �� $��20��6$   $��20��6/   $��Assets/plus.png��6;   $��5q�6T   $��Center=�6_   �� 56      $��
Create New��6(    �� Padding$ 10q�6:   $	��200��6G   57      58      �� 59      $��45��6#   $��0q�6/   .��5:      �� -   5        $ 
Horizontal=�5:   %   $��10 0 0 0q�6>   $	��230��6P   .+�5;      �� $��20��6$   $��20��6/   $��Assets/load.png��6;   $��5q�6T   $��Center=�6_   �� 5<      $
��Load��6(   $ 10q�64   $	��200��6A   5=      5>      �� 5?      $��45��6#   $��0q�6/   .��5@      �� $ 
Horizontal=�6%   $��10 0 0 0q�6>   $	��230��6P   .+�5A      �� $��20��6$   $��20��6/   $��Assets/save.png��6;   $��5q�6T   $��Center=�6_   �� 5B      $��Save as��6(   $ 10q�67   $	��200��6D   5C      5D      �� 5E      $��45��6#   $��0q�6/   .��5F      �� $ 
Horizontal=�6%   $��10 0 0 0q�6>   $	��230��6P   .+�5G      �� $��20��6$   $��20��6/   $��Assets/settings.png��6;   $��5q�6X   $��Center=�6c   �� 5H      $��Settings��6(   $ 10q�68   $	��200��6E   5I      5J      �� 5K      $��45��6#   $��0q�6/   .��5L      �� -   5        $ 
Horizontal=�5L   %   $��10 0 0 0q�6>   $	��230��6n   .+�5M      �� $��20��6$   $��20��6/   $��Assets/exit.png��6;   $��5q�6T   $��Center=�6_   �� 5N      $
��Exit��6(   $ 10q�64   $	��200��6A   5O      5P      5Q      5R      �� 5S      -   5        $ ButtonClose��5S      $��Right=�6*   $	��Top=�6F   $��25��6�   $��25��6�   $��0q�6�   ��6^   Z� ��6t   Z� .��5T      �� $��Assets/close.png��6   5U      5V      5W      5X      