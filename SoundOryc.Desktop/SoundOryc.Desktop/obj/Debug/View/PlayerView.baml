   M S B A M L   `   `   `  ����L  HSoundOryc.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SoundOryc.Desktop.ViewModelSoundOryc.Desktop.ViewModel  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5	      '    !SoundOryc.Desktop.View.PlayerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;model)clr-namespace:SoundOryc.Desktop.ViewModel     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      WcmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform  5	      $	��600��5        � DataContext  5
      �� *Player+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Resources.xaml?�6&   �� 5      $K Epack://application:,,,/MahApps.Metro;component/Styles/FlatSlider.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��9 �6   �� 5      $��51 �6    � ColumnDefinitions 5   
   �� 5      $
��197* �6   �� 5       $
��100* �6   �� 5!      $��44 �6   �� 5"      $	��91* �6   �� 5#      $
��197* �6   .+�5&   
   �� -   5         ��Name$ psTimeProgress��5&      $��0��6)   $��0��69   $��5��6F   $��0,0,0,56q�6Z     
FlatSlider#���  6�   $
��Auto��6�   ���	#FFF79F8B���	#FF979797���	#FF979797$
��Auto��6<  $��2��6J   �� IsMoveToPointEnabled . 	 � Value	 6l   �� *sliderContent+
 �� Mode$
 OneWay=� � Maximum 6�   �� *	sliderMax+$
 OneWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5'      /  )System.Windows.Interactivity.EventTrigger  5(         	EventName$ PreviewMouseLeftButtonUp��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5)      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6)   �� *sliderClick+6I   5*      5,      �� 5-   
   -   5         ��Name$ lblActualTime��5-      $��0��6N   $��0��6^   $��Arial Unicode MS)�6k   ���	#FF898C88$
��Left=�6�   $	��5,0q�6�   
������ }�. $��10(�6�   $��	-1,4,0,41q�6  $��2��6  $��41��6)  ��6(   �� *actualTimeContent+6)  �� 5.   
   -   5        $ lblTotalTime��5.      $��4��6L   $��0��6\   $��Arial Unicode MS)�6i   ���	#FF898C88$	��5,0q�6�   
������ }�. $��10(�6�   $��0,4,0,41q�6�   $��2��6�   $��Right=�6  $��36��6'  ��6'   �� *totalTimeContent+6'  �� 5/   
   $��20,5,0,0q�6   $��0��6'   $��1��67   $
��Left=�6D   $
��auto��6_   .+�50      �� -   5        $ lblArtistName��50      $��Arial Unicode MS)�6p   $
��Bold"�6�   ���	#FF898C88$��13(�6�   $��25��6�   $��2,5,5,2q�6�   $
��Left=�6�   ��6+   �� *
artistName+ � ToolTip 6J   �� *artistNameTooltip+6�   �� 51      -   5        $ lblSongName��51      $��Arial Unicode MS)�6G   ���	#FF898C88$
��Left=�6|   $	��5,0q�6�   ��6*   �� *
songName+6�   52      �� 53   
   -   5         ��Name$ btnQueue��53        ButtonStyle#��[ 6#   $��3��6I   $��1��6Y   $��18��6f   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6�   $y�Visible=�6�   $ Songs Queue��6�    J� RenderTransformOrigin$ 0.529,0.917&�6  $��56.731,16,1.54,17q�67  .��54      C�  C� ResourceKey$ queueButton��6    55        56      $ Click��6!   . 57         6)   �� *openCloseQueue+58      5:      �� 5;   
   -   5        $ btnPrev��5;        prevButtonStyle#��[ 6?   $��1��6h   $��1��6x   $��	0,17,0,19q�6�   $��15��6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��Right=�6�   $��15��6  $��1��69  $y�Visible=�6G  ��6"   �� *
prevSong+{�6  �� *isPrevBtnEnabled+6G  �� 5>   
   -   5        $ btnPlayPause��5>      $��2��6'   $��1��67   $��3,3,1,8q�6D   $��40��6U   $��40��6`     MetroCircleButtonStyle#���  6l   ���	#FFF79F8B$��0q�6�   ��6�   �� *	pausePlay+.��5?      �� ��5@      �� 5A       �� 
TargetType" ��6   .�5B      ��  �� Property � �� �� Value$ /Resources/playButton.png��63   �� 5C       � ��$ 10��62   �� 5D       � ��$ 
3, 0, 0, 0q�63    �� Triggers 5E      �� 5F       �� Binding 6*   �� *isSongPaused+ �� Value	 False6K   .a�5G   "   ��  � ��$  /Resources/pauseButton.png��6;   �� 5H   "    � ��$ 
1, 0, 0, 0q�6;   5I      5K      5M      5N      �� 5O   
   -	   5        $ btnNext��5O        nextButtonStyle#��[ 6@   $��3��6i   $��1��6y   $��	0,17,0,19q�6�   $��15��6�   $
��Left=�6�   $��15��6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6  $��1��6F  $y�Visible=�6T  ��6#   �� *
nextSong+{�6  �� *isNextBtnEnabled+6T  �� 5P   
   -
   5        $ psVolume��5P        Horizontal_Slider#��[ 6#   $��4��6O   $��1��6_   $��
0,13,10,12q�6l   $��96��6�   $	 100Q�6�    �� Interval$ 30��6�   $��Right=�6�   ���	#00000000 . 	 6�   �� *volumeValue+6�   �� 5Q   
   -   5        $ btnPlayMode��5Q      #��[ 6I   $��1��6o   $��1��6   $��10,15,65,16q�6�   $��20��6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6�   {�. $��1��6  $y�Visible=�6!  $ 	Play mode��66  ��6&   �� *changePlayMode+.��5R      �� ��5S      �� 5T      " ��6   .�5U      ��  � ��$$ /Resources/RepeatAllButton.png��63    5V      �� 5W       6*   �� *selectedPlayModeOption+ rone6U   .a�5X   "   ��  � ��$$ /Resources/RepeatOneButton.png��6;   5Y      �� 5Z       6*   �� *selectedPlayModeOption+ shuffle6U   .a�5[   "   ��  � ��$$ /Resources/shuffleOnButton.png��6;   5\      5^      5`      5a      �� 5b   
   -   5        $ 	btnVolume��5b      #��[ 6%   $��4��6n   $��4��6~   $��0,14,119,17q�6�   $��15��6�   $��Right=�6�   $��15��6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6  {�. $��1��68  $y�Visible=�6F  ��6K   �� *muteUnmuteSong+.��5c      �� ��5d      �� 5e      " ��6   .�5f      ��  � ��$! /Resources/volumeButton.png��63    5g      �� 5h       6*   �� *IsVolumeMuted+	 False6L   .a�5i   "   ��  � ��$% /Resources/volumeButtonMute.png��6;   5j      5l      5n      5o      5p      5q      