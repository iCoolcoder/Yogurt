 
# what: convert a compressed audio file into the universal WAV format
# step 1: prepare decoder
# step 2: decode data
# step 3: prepare encoder
# step 4: encoder data that has been decoded
# step 5: write data that has been encoded to file as .wav

def dumpWAV(file_path):
    import pymedia.muxer as muxer
    import pymedia.audio.acodec as acodec
    import os.path as path
    import wave

    root, ext = path.splitext(file_path)
    demuxer = muxer.Demuxer(ext[1:].lower())
    file = open(file_path, 'rb')
    try:
        wav_file = None
        data = ' '
        decoder = None
        while data:
            data = file.read(20000)
            if len(data):
                frames = demuxer.parse(data)
                for frame in frames:
                    if decoder == None:
                        decoder = acodec.Decoder(demuxer.streams[0])
                    audio_frame = decoder.decode(frame[1])
                    if audio_frame and audio_frame.data:
                        if wav_file == None:
                            wav_file = wave.open(root + '.wav', 'wb')
                            wav_file.setparams((audio_frame.channels, 2, audio_frame.sample_rate, 0, 'NONE', ''))
                        wav_file.writeframes(audio_frame.data)
    finally:
        file.close()
        if wav_file != None:
            wav_file.close()

import sys
if __name__ == '__main__':
    if sys.argv != 2:
        print 'Usage:dumpwav.py target_file'
    else:
        dumpWAV(sys.argv[1])

