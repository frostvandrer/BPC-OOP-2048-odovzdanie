   M S B A M L   `   `   `  ����  2048-WPF    _2048_WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5          �Name$  window��5   	    � Title$
 2048��5   	   $	��500��5   	   $	��500��5   	    � 
ResizeMode$ NoResize=�5	   	   
������� J� InputBindings 5      �� 5   
   
 �� Key$ Up��6    �� Command 6   �� *MoveUpCommand+�� 5   
   $ w��6    6   �� *MoveUpCommand+�� 5   
   $
 Down��6    6    �� *MoveDownCommand+�� 5   
   $ s��6    6   �� *MoveDownCommand+�� 5   
   $
 Left��6    6    �� *MoveLeftCommand+�� 5   
   $ a��6    6   �� *MoveLeftCommand+�� 5   
   $ Right��6    6!   �� *MoveRightCommand+�� 5   
   $ d��6    6   �� *MoveRightCommand+.��5      � .+�5   
    � -   5        $��	MainFrame��5        � NavigationUIVisibility$ Hidden=�6!   5      5      