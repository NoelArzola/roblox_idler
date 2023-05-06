# roblox_idler.py

"""Roblox Idler is an idling tool for Roblox built with Python"""

import keyboard
import time

ERROR_MSG = 'ERROR: Invalid Input. Exiting program. Please launch again with a valid number.'

keep_alive = True

class Idler():

    def __init__(self):
        super().__init__()
        self.user_input = self._grab_input() 

    def _validate_input(self, interval):
        if (interval < 1 or interval > 19):
            print(ERROR_MSG)
            return False
        
        return True
    
    def _grab_input(self):
        user_value = input('How often (in minutes) should be move your avatar? Enter a number from 1-19 (default is 5): ')
        
        if (user_value in ['', ' ', '  ']):
            user_value = 5
            print('Using default value of 5 minutes!')
        
        try:
            user_value = int(user_value)
        except ValueError:
            print(ERROR_MSG)
            return
        
        return user_value
            
    def _simulate_gameplay(self, user_input):
        keyboard.send('w')
        time.sleep(1)
        keyboard.send('a')
        time.sleep(1)
        keyboard.send('s')
        time.sleep(1)
        keyboard.send('d')
        time.sleep(1)
        keyboard.send('space')
        time.sleep(60 * user_input)

    def _end_simulation(self):
        global keep_alive
        keep_alive = False
        print('Q was pressed, exiting after the current job.\nTo quit immediately hit "ctrl+c"')

    def _run_idler(self) :
        if (self._validate_input(self.user_input)):
            print('Starting idler in ten seconds. Please switch to your game.')
            global keep_alive
            time.sleep(10)
            keyboard.add_hotkey('q', lambda: self._end_simulation())
            print('Idler is running. Press Q anytime to exit')
            while (keep_alive):
                self._simulate_gameplay(self.user_input)

idler = Idler()
idler._run_idler()