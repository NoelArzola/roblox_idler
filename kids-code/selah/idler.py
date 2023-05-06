# name = 'Ariana'
# print('hello world. it tis I, ')
# print(name)
# print('Hello world it tis I, ' + name)
# def printer(name):
# print('haii, ' + name)
# printer('Manny')

import keyboard
import time

keep_alive = True 
ERROR_MSG = 'FBI OPEN UP'

class Idler():

    def __init__(self):
        super().__init__()
        self.user_input = self.gem_input()

    def validate_input(self, interval):
        if (interval < 1 or interval > 19):
            print(ERROR_MSG)
            return False
        return True

    def gem_input(self):
        user_value = input('How often should we move your avatar? Enter a number from 1-19 (default is 5):')

        if (user_value in ['', ' ', '  ']):
            user_value = 5 
            print('Using the default value of 5')

        try:
            user_value = int(user_value)
        except:
            print('Please Hold')
            return
        
        return user_value

    def begin_playing(self, user_input):
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

    def stop_playing(self):
        global keep_alive 
        keep_alive = False
        print('Q Was pressed, exiting..\nTo quit immediately hit "crtl\cmd + c"')

    def run_idler(self):
        if (self.validate_input(self.user_input)):
            print('Starting idler in ten seconds. Please Switch to your game.')
            global keep_alive
            time.sleep(10)
            keyboard.add_hotkey('q', lambda: self.stop_playing())
            print('Idler is running. Press Q to Be a Quiter :)')
            while (keep_alive):
                self.begin_playing(self.user_input)

idler = Idler()
idler.run_idler()