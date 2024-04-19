mkdir android/app/src/main/assets
cp android/app/src/main/res/drawable-hdpi/notification_icon.png android/app/src/main/res/drawable
npx react-native bundle --platform android --dev false --entry-file index.js --bundle-output android/app/src/main/assets/index.android.bundle --assets-dest android/app/src/main/res
rm -rf ./android/app/src/main/res/raw
rm -rf ./android/app/src/main/res/drawable-*
cd android
./gradlew assembleRelease
adb install app/build/outputs/apk/release/app-release.apk